namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class TimesheetWorklog
    {
        public int ActivityId { get; set; }
        public List<Worklog> Worklog { get; set; }
    }
}
