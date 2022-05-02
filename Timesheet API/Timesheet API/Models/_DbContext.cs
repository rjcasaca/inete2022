using Microsoft.EntityFrameworkCore;

namespace Timesheet_API.Models
{
    public class _DbContext:DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }

        public DbSet<User> users { get; set; }
    }
}
