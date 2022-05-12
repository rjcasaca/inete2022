using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.Activity
{
    public class PostActivity
    {
        [MaxLength(150)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Models.Project Project { get; set; }
        public Models.ActivityState ActivityState { get; set; }
        public Models.ActivityType ActivityType { get; set; }
    }
}
