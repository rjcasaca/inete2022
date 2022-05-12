using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timesheet_Expenses_API.Models
{
    [Table(name:"File Content")]
    public class FileContent
    {
        [Key]
        public int FileContent_Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }

        //Navigation Properties
        public FileContType FileContType { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public List<Activity_File> Activity_File { get; set; }
        public List<Expense_File> Expense_File { get; set; }
    }
}
