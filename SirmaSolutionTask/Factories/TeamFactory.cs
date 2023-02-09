namespace SirmaSolutionTask.Factories
{
    using SirmaSolutionTask.Models;
    public class TeamFactory
    {
        public static Team Execute(long firstEmployeeId, long secondEmployeeId, long overlapDuration, long projectId)
        {
            return new Team(firstEmployeeId, secondEmployeeId, overlapDuration, projectId);
        }
    }
}
