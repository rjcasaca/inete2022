namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class ActivityInfo
    {
        public ActivityIdName ActivityIdName { get; set; }
        public string ActivityState { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDescription { get; set; }
        public ProjectsIdName ProjectInfo { get; set; }
        public List<CommentText> ActivityComments { get; set; }
    }
}
