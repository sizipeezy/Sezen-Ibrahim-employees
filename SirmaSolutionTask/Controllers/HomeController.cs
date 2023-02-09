namespace SirmaSolutionTask.Controllers
{
    using Employees.Constants;
    using Microsoft.AspNetCore.Mvc;
    using SirmaSolutionTask.Contracts;
    using SirmaSolutionTask.Factories;
    using SirmaSolutionTask.FileService;
    using SirmaSolutionTask.Models;
    using SirmaSolutionTask.Repository;


    public class HomeController : Controller
    {
        EmployeeService EmployeeService = new EmployeeService(new EmployeeRepository());
        List<string> fileLines = FileReader.Read(ApplicationConstants.FilePath);

        public IActionResult Index()
        {
            List<DatabaseRecord> records = new List<DatabaseRecord>();
            foreach (var line in fileLines)
            {
                records.Add(DatabaseRecordFactory.Start(line));
            }

            //Save all employee records into "database"
            EmployeeService.AddEmployee(records);

            //Find all team, couple of employees which r worked under same project and have overlap
            List<Team> teams = EmployeeService.FindAllTeamsWithOverLap();

           var result = teams.Select(x => new ResultViewMOdel
           {
               EmployeeId1 = x.firstEmployeeId,
               EmployeeId2 = x.secondEmployeeId,
               Days = x.totalDuration,
               ProjectId = x.projectId,
           }).ToList();

            return View(result);
        }
    }
}