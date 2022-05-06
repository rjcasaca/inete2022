using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"User Function")]
    public class UserFunction
    {
        [Key]
        public int UserFunc_Id { get; set; }
        [Required, MaxLength(30)]
        public string Function { get; set; }
    }
}
