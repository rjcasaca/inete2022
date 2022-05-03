
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace ExpenseAPI.Models
{
    [Table(name:"user")]
    public class User
    {
        [Key,MaxLength(100)]
        public string Email { get; set; } 
        [Required, MaxLength(50)]
        public string Name { get; set; }
    }
}
