namespace SirmaSolutionTask.Repository
{
    using SirmaSolutionTask.Models;
    using System.Collections.Generic;


    public class EmployeeRepository
    {
        private List<DatabaseRecord> data;

        public EmployeeRepository()
        {
            this.data = new List<DatabaseRecord>();
        }

        public void SaveRecord(DatabaseRecord record)
        {
            this.data.Add(record);
        }

        public void SaveAllRecords(List<DatabaseRecord> records)
        {
            this.data.AddRange(records);
        }

        public List<DatabaseRecord> GetAllRecords() => this.data;
    }
}
