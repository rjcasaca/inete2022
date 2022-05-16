namespace Timesheet_Expenses_API.Models.Object.Expense
{
    public class LinesObj
    {
        public int Cod_Line { get; set; }
        public decimal UnityPrice { get; set; }
        public DateTime Date { get; set; }

        //Navigation Properties
        public int Expense { get; set; }
    }
}
