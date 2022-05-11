using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.UserFunction
{
    public class PostUserFunction
    {
        [Required, MaxLength(30)]
        public string Function { get; set; }
    }
}
