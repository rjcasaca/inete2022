using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"User")]
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required, MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }

        //Navigation Properties
        public List<Team> teams { get; set; }
    }
}
