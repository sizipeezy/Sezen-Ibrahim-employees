namespace SirmaSolutionTask.Contracts
{
    using Employees.Constants;
    using SirmaSolutionTask.Factories;
    using SirmaSolutionTask.Models;
    using SirmaSolutionTask.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class EmployeeService : EmployeeServiceInterface
    {
        private EmployeeRepository emplRepo;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            this.emplRepo = employeeRepository;
        }

        /* Method which save all DatabaseRecords to the database using EmployeeRepository */
        public void AddEmployee(List<DatabaseRecord> DatabaseRecords)
        {
            this.emplRepo.SaveAllRecords(DatabaseRecords);
        }
        public List<Team> FindAllTeamsWithOverLap()
        {
            List<DatabaseRecord> allDatabaseRecords = this.emplRepo.GetAllRecords();

            List<Team> teams = new List<Team>();
            for (int i = 0; i < allDatabaseRecords.Count() - 1; i++)
            {
                for (int j = i + 1; j < allDatabaseRecords.Count(); j++)
                {
                    DatabaseRecord firstEmpl = allDatabaseRecords[i];
                    DatabaseRecord secondEmpl = allDatabaseRecords[j];

                    if (firstEmpl.getProjectId() == secondEmpl.getProjectId()
                            && HasOverlap(firstEmpl, secondEmpl))
                    {
                        long overlapDays = CalcOverlap(firstEmpl, secondEmpl);

                        if (overlapDays > 0)
                        {
                            UpdateTeam(teams, firstEmpl, secondEmpl, overlapDays, firstEmpl.getProjectId());
                        }
                    }
                }
            }
            return teams;
        }

        private long CalcOverlap(DatabaseRecord firstEmpl, DatabaseRecord secondEmpl)
        {
            DateTime periodStartDate =
                    firstEmpl.getDateFrom() < (secondEmpl.getDateFrom()) ?
                            secondEmpl.getDateFrom() : firstEmpl.getDateFrom();

            DateTime periodEndDate =
                    firstEmpl.getDateTo() < (secondEmpl.getDateTo()) ?
                            firstEmpl.getDateTo() : secondEmpl.getDateTo();

           
            return Math.Abs((periodEndDate - periodStartDate).Days);
        }

        /** hasOverlap method returning if two employees have overlap */
        private bool HasOverlap(DatabaseRecord firstEmpl, DatabaseRecord secondEmpl)
        {
            //have overlap if (startA <= endB) and (endA >= startB)
            return (firstEmpl.getDateFrom() < secondEmpl.getDateTo()
                    || firstEmpl.getDateFrom() == secondEmpl.getDateTo()
                    && firstEmpl.getDateTo() > secondEmpl.getDateFrom()
                    || firstEmpl.getDateTo() == secondEmpl.getDateFrom());
        }

        private bool IsTeamPresent(Team team, long firstEmplId, long secondEmplId)
        {
            return (team.firstEmployeeId == firstEmplId
                    && team.secondEmployeeId == secondEmplId)
                    || (team.firstEmployeeId == secondEmplId
                    && team.secondEmployeeId == firstEmplId);
        }

       
        /** If the team is already present, it's total overlap duration will be updated with the new value,
         * otherwise will be create and add new team with the current data */
        private void UpdateTeam(List<Team> teams, DatabaseRecord firstEmpl, DatabaseRecord secondEmpl, long overlapDays, long projectId)
        {
            bool isPresent = false;

            foreach (var team in teams)
            {
                if (IsTeamPresent(team, firstEmpl.getEmployeeId(), secondEmpl.getEmployeeId()))
                {
                    team.AddOverLapDuration(overlapDays);
                    isPresent =true;
                }
            }
            //If the team isn't present -> create and add new team with the current data
            if (!isPresent)
            {
                Team newTeam = TeamFactory.Execute(
                        firstEmpl.getEmployeeId(),
                        secondEmpl.getEmployeeId(),
                        overlapDays,
                        projectId);
                teams.Add(newTeam);
            }
        }
    }
}
