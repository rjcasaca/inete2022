namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class TimesheetWorklog
    {
        public ActivityInfo Activity { get; set; }
        public List<WorklogInfo> WeekWorklog { get; set; }

    }
}
