using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense")]
    public class Expense
    {
        [Key]
        public int Expense_Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalMoney { get; set; }
        public int Qtd_Line { get; set; }

        //Navigation Properties
        public ExpenseType ExpenseType { get; set; }
        public User User { get; set; }
        public Project Project { get; set; }
        public List<Expense_File> Expense_File { get; set; }
        public List<Line> Line { get; set; }
    }
}
