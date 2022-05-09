using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Activity Type")]
    public class ActivityType
    {
        [Key]
        public int ActivityType_Id { get; set; }
        [Required, MaxLength(30)]
        public string Type { get; set; }
    }
}
