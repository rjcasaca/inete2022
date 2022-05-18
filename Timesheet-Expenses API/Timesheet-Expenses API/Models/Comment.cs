using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Comment")]
    public class Comment
    {
        [Key]
        public int Comment_Id { get; set; }
        public string Text { get; set; }

        //Navigation Properties
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
