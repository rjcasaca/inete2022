using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Team")]
    public class Team
    {
        [MaxLength(100)]
        public string TeamName { get; set; }

        //Navigation Properties
        public int User { get; set; }
        public User user { get; set; }
        public int Project { get; set; }
        public Project project { get; set; }

        public UserFunction function { get; set; }
    }
}
