namespace Timesheet_Expenses_API.Models.Entities.Expense_File
{
    public class PutExpense_File:PostExpense_File
    {
        public int FileContentId { get; set; }
        public int ExpensesId { get; set; }
    }
}
