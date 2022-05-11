using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"FileCont Type")]
    public class FileContType
    {
        [Key]
        public int FileContTypeId { get; set; }
        [Required]
        public string Type { get; set; }

        //Navigation Properties
        public List<FileContent> FileContent { get; set; }
    }
}
