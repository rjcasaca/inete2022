using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Users")]
    public class Users
    {
        [Key]
        public int User_Id { get; set; }
        [Required, MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
