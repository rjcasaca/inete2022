using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense Type")]
    public class ExpenseState
    {
        [Key]
        public int ExpenseTypeId { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
