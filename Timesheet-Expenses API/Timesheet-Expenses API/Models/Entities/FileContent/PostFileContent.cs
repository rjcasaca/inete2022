using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.FileContent
{
    public class PostFileContent
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public int FileId { get; set; }
        public Models.FileContentType FileContentType { get; set; }
    }
}
