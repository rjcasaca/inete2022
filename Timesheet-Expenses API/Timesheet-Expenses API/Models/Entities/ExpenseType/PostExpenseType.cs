using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.ExpenseType
{
    public class PostExpenseType
    {
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
