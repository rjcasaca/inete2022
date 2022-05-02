using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_API.Models
{
    [Table(name: "User")]
    public class User
    {
        [Key, MaxLength(254)]
        public string email { get; set; }
        [Required, MaxLength(250)]
        public string name { get; set; }
    }
}
