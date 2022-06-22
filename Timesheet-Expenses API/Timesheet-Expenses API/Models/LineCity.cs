using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models

    {[Table(name: "LineCity")]
    public class LineCity
    {
        [Key]
        public int LineCityID { get; set; }
       public string City { get; set; }
        // migrations
        public List<Line> line { get; set; }

    }
}

