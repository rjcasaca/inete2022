using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseAPI.Models
{
    
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        
        
        }
        public DbSet<User> user { get; set; }

    }
}
