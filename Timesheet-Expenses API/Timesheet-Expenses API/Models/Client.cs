using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Client")]
    public class Client
    {
        [Key]
        public int Client_Id { get; set; }
        [Required, MaxLength(250)]
        public string Name { get; set; }
        [Required, MaxLength(254)]
        public string Email { get; set; }

        //Navigation Properties
        public Project Project { get; set; }
    }
}
