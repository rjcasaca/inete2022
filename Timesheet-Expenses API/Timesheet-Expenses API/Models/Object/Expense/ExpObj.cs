namespace Timesheet_Expenses_API.Models.Object.Expense
{
    public class ExpObj
    {
       
        public DateTime Date { get; set; }
        public decimal TotalMoney { get; set; }
        public int Qtd_Line { get; set; }

        //Navigation Properties
        public string ExpenseType { get; set; }
        public string ExpenseState { get; set; }
     public string User { get; set; }
        public string project_id  { get; set; }
        public string Expense_File { get; set; }
        public string Line { get; set; }
    }

}
