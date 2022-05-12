namespace Timesheet_Expenses_API.Models.Entities.Activity_File
{
    public class PutActivity_File:PostActivity_File
    {
        public int ActivityId { get; set; }
        public int FileContentId { get; set; }
    }
}
