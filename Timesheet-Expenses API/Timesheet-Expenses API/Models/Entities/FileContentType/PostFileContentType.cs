using System.ComponentModel.DataAnnotations;

namespace Timesheet_Expenses_API.Models.Entities.FileContentType
{
    public class PostFileContentType
    {
        [MaxLength(30)]
        public string Type { get; set; }
    }
}
