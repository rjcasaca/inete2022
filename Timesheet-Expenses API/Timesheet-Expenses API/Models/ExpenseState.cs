using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name: "Expense State")]
    public class ExpenseState
    {
        [Key]
        public int ExpenseState_Id { get; set; }
        [Required, MaxLength(30)]
        public string State { get; set; }

        //Navigation Properties
        public List<Expense> Expenses { get; set; }
    }
}
