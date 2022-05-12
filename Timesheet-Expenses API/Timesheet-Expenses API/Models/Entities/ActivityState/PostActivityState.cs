using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.ActivityState
{
    public class PostActivityState
    {
        [MaxLength(30)]
        public string State { get; set; }
    }
}
