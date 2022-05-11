using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.Client
{
    public class PostClient
    {
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(254)]
        public string Email { get; set; }
    }
}
