using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.ExpenseState
{
    public class PostExpenseState
    {
        [Required, MaxLength(30)]
        public string State { get; set; }
    }
}
