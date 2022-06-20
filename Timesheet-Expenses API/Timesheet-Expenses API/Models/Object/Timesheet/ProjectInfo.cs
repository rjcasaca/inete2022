namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class ProjectInfo
    {
        public ProjectsIdName ProjectsIdName { get; set; }
        public List<ActivityIdName> ProjectActivities { get; set; }
        public string ProjectState { get; set; }
        public ClientEmailName Client { get; set; }
        public int StartDay { get; set; }
        public int StartMonth { get; set; }
        public int StartYear { get; set; }
        public int EndDay { get; set; }
        public int EndMonth { get; set; }
        public int EndYear { get; set; }
        public List<TeamInfo> Teams { get; set; }
    }
}
