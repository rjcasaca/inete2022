using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.ProjectState
{
    public class PostProjectState
    {
        [MaxLength(30)]
        public string State { get; set; }
    }
}
