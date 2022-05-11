using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.WorklogState
{
    public class PostWorklogState
    {
        [MaxLength(50)]
        public string State { get; set; }
    }
}
