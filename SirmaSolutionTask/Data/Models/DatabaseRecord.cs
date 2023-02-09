namespace SirmaSolutionTask.Models
{
    public class DatabaseRecord
    {
        private long employeeId;
        private long projectId;
        private DateTime dateFrom;
        private DateTime dateTo;

        public DatabaseRecord(long employeeId, long projectId, DateTime dateFrom, DateTime dateTo)
        {
            this.setEmployeeId(employeeId);
            this.setProjectId(projectId);
            this.setDateFrom(dateFrom);
            this.setDateTo(dateTo);
        }

        public long getEmployeeId()
        {
            return this.employeeId;
        }

        private void setEmployeeId(long employeeId)
        {
            this.employeeId = employeeId;
        }

        public long getProjectId()
        {
            return this.projectId;
        }

        private void setProjectId(long projectId)
        {
            this.projectId = projectId;
        }

        public DateTime getDateFrom()
        {
            return this.dateFrom;
        }

        private void setDateFrom(DateTime dateFrom)
        {
            this.dateFrom = dateFrom;
        }

        public DateTime getDateTo()
        {
            return this.dateTo;
        }

        private void setDateTo(DateTime dateTo)
        {
            this.dateTo = dateTo;
        }
    }
}