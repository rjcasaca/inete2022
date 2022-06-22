namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class TimesheetActivityWorklog
    {
        public int ActivityId { get; set; }
        public List<TimesheetWorklog> timesheetWorklogs { get; set; }
    }
}
