namespace Timesheet_Expenses_API.Models.Entities.Expense
{
    public class PostExpense
    {
        public DateTime Date { get; set; }
        public decimal TotalMoney { get; set; }
        public int Qtd_Line { get; set; }

        //Navigation Properties
        public Models.ExpenseType ExpenseType { get; set; }
        public Models.ExpenseState ExpenseState { get; set; }
        public Models.User User { get; set; }
        public Models.Project Project { get; set; }
    }
}
