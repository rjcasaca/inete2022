using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models


{
    [Table(name: "LineType")]
    public class LineType
    {
        [Key]
        public int LineTypeID { get; set; }
        public string Type { get; set; }
        // migrations
        public Line line { get; set; }

    }
}
