using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"File Content Type")]
    public class FileContentType
    {
        [Key]
        public int FileContentType_Id { get; set; }
        [Required, MaxLength(30)]
        public string Type { get; set; }

        //Navigation Properties
        
    }
}
