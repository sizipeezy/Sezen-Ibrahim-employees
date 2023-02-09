namespace SirmaSolutionTask.Models
{
    public class Team
    {
        public long firstEmployeeId { get; set; }
        public long secondEmployeeId { get; set; }
        public long totalDuration { get; set; }
        public long projectId { get; set; }

        public Team(long firstEmployeeId, long secondEmployeeId, long totalDuration, long projectId)
        {
            this.firstEmployeeId = firstEmployeeId;
            this.secondEmployeeId = secondEmployeeId;
            this.totalDuration = totalDuration;
            this.projectId = projectId;
        }

        public void AddOverLapDuration(long overlap)
        {
            this.totalDuration += overlap;
        }
    }
}
