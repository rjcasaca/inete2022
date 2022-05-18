using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name: "Team")]
    public class Team
    {
        [Required, MaxLength(100)]
        public string TeamName { get; set; }

        //Navigation Properties
        public int UserId { get; set; }
        public User user { get; set; }

        public int ProjectId { get; set; }
        public Project project { get; set; }


        public int UserFunctionId { get; set; }
        public UserFunction UserFunction { get; set; }
    }
}
