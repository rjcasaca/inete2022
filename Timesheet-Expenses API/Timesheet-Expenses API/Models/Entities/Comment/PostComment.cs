namespace Timesheet_Expenses_API.Models.Entities.Comment
{
    public class PostComment
    {
        public string Text { get; set; }

        //Navigation Properties
        public Models.Activity Activity { get; set; }
    }
}
