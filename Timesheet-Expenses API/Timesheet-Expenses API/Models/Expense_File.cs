using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense_File")]
    public class Expense_File
    {
        //Navigation Properties
        public int FileContentId { get; set; }
        public FileContent FileContent { get; set; }

        public int ExpenseId { get; set; }
        public Expense Expenses { get; set; }
    }
}
