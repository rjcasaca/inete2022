using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"File")]
    public class File
    {
        [Key]
        public int File_Id { get; set; }
        [Required]
        public string base64 { get; set; }

    
    }
}
