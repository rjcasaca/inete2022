using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Expense Type")]
    public class ExpenseType
    {
        [Key]
        public int ExpenseType_Id { get; set; }
        [Required, MaxLength(30)]
        public string Type { get; set; }

        //Navigation Properties
        public List<Expense> Expenses { get; set; }
    }
}
