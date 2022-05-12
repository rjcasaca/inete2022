namespace Timesheet_Expenses_API.Models.Entities.Line
{
    public class PostLine
    {
        public decimal UnityPrice { get; set; }
        public DateTime Date { get; set; }

        //Navigation Properties
        public Models.Expense Expenses { get; set; }
    }
}
