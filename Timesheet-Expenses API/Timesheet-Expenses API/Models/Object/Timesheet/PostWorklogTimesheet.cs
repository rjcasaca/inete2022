namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class PostWorklogTimesheet
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Hours { get; set; }
        public string Comment { get; set; }
        public int Activity { get; set; }
        public string BillingType { get; set; }
        public string WorklogState { get; set; }
    }
}
