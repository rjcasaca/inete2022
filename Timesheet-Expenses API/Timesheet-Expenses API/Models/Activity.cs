using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Activity")]
    public class Activity
    {
        [Key]
        public int Activity_Id { get; set; }
        [Required, MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }

        //Navigation Properties
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int ActivityStateId { get; set; }
        public ActivityState ActivityState { get; set; }

        public int ActivityTypeId { get; set; }
        public ActivityType ActivityType { get; set; }


        public List<User_Activity> user_Activities { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Worklog> Worklog { get; set; }
        public List<Activity_File> Activity_File { get; set; }
    }
}
