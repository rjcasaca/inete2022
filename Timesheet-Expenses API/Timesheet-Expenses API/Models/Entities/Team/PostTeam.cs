using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.Team
{
    public class PostTeam
    {
        [MaxLength(100)]
        public string TeamName { get; set; }
        public Models.UserFunction UserFunction { get; set; }
        public Models.Project project { get; set; }
        public Models.User user { get; set; }
    }
}
