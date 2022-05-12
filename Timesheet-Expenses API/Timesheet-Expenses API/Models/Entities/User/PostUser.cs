using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.User
{
    public class PostUser
    {
        [MaxLength(254)]
        public string Email { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
