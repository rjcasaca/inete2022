using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.UserFunction
{
    public class PostUserFunction
    {
        [MaxLength(30)]
        public string Function { get; set; }
    }
}
