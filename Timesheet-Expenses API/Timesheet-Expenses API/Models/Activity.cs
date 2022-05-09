using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Activity")]
    public class Activity
    {
        [Key]
        public int Activity_Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Properties
        public List<User> users { get; set; }
        public List<Project> projects { get; set; }
        public List<ActivityType> activityTypes { get; set; }
    }
}
