using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"Activity_File")]
    public class Activity_File
    {
        //Navigation Properties
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

        public int FileContentId { get; set; }
        public FileContent FileContent { get; set; }
    }
}
