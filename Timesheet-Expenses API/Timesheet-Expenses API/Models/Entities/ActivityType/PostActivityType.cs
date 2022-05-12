using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.ActivityType
{
    public class PostActivityType
    {
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
