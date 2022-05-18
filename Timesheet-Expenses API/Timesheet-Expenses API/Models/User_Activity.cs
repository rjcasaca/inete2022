using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name: "User_Activity")]
    public class User_Activity
    {
        //Navigation Properties
        public int UserId { get; set; }
        public User user { get; set; }

        public int ActivityId { get; set; }
        public Activity activity { get; set; }
    }
}
