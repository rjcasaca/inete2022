namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class ProjectInfo
    {
        public ProjectsIdName ProjectsIdName { get; set; }
        public List<ActivityIdName> ProjectActivities { get; set; }
        public string ProjectState { get; set; }
        public ClientEmailName Client { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TeamInfo> Teams { get; set; }
    }
}
