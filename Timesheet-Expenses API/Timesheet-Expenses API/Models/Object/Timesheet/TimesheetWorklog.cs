namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class TimesheetWorklog
    {
        public ActivityIdName Activity { get; set; }
        public WorklogInfo Monday { get; set; }
        public WorklogInfo Tuesday { get; set; }
        public WorklogInfo Wednesday { get; set; }
        public WorklogInfo Thursday { get; set; }
        public WorklogInfo Friday { get; set; }
        public WorklogInfo Saturday { get; set; }
        public WorklogInfo Sunday { get; set; }

    }
}
