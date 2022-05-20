namespace Timesheet_Expenses_API.Models
{
    public class Bill
    {
   
        public byte[] base64 { get; set; }
        
        public string Name { get; set; }
        public int FileContentTypeId { get; set; }
       public int expenseid { get; set; }   
        public int FileId { get; set; }
        public string Type { get; set; }
        public int FileContentId { get; set; }
        public int FileContent_Id { get; set; }

    }
}
