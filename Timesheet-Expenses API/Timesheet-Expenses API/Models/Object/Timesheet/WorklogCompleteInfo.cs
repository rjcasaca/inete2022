namespace Timesheet_Expenses_API.Models.Object.Timesheet
{
    public class WorklogCompleteInfo
    {
        public string ActivityName { get; set; }
        public string Comment { get; set; }
        public string WorklogState { get; set; }
        public string BillingType { get; set; }
        public decimal Hours { get; set; }
        public DateTime Date { get; set; }
    }
}
