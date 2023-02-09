namespace SirmaSolutionTask.Factories
{
    using SirmaSolutionTask.Models;
    using System;
    using System.Linq;


    public static class DatabaseRecordFactory
    {
        private static string NullConst = "NULL";

        public static DatabaseRecord Start(string line)
        {
            var recordArgs = line.Replace(" ", "").Split(',').ToArray();

            long emplID = long.Parse(recordArgs[0].Trim(' '));
            long projectID = long.Parse(recordArgs[1].Trim(' '));

            DateTime dateFrom = DateTime.Parse(recordArgs[2]);

            DateTime dateTo;

            if (recordArgs[3] == null || NullConst.Equals(recordArgs[3]))
            {
                dateTo = DateTime.Now;
            }
            else
            {
                dateTo = DateTime.Parse(recordArgs[3]);
            }

            return new DatabaseRecord(emplID, projectID, dateFrom, dateTo);
        }
    }
}
