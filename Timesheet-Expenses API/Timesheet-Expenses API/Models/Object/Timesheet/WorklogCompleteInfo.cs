namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class WorklogCompleteInfo
    {
        public string ActivityName { get; set; }
        public int ActivityId { get; set; }
        public string Comment { get; set; }
        public string WorklogState { get; set; }
        public string BillingType { get; set; }
        public decimal Hours { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
