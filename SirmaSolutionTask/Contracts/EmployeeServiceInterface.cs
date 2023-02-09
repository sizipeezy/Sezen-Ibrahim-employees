namespace SirmaSolutionTask.Contracts
{
    using SirmaSolutionTask.Models;
    using System.Collections.Generic;


    public interface EmployeeServiceInterface
    {
        void AddEmployee(List<DatabaseRecord> records);

        List<Team> FindAllTeamsWithOverLap();
    }
}
