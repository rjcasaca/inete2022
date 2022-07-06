namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class UserActivityWorklogs
    {
        public int worklogId { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal hours { get; set; }
    }
}
