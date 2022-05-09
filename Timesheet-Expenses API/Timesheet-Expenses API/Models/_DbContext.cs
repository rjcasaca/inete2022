using Microsoft.EntityFrameworkCore;

namespace Timesheet_Expenses_API.Models
{
    public class _DbContext: DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        { }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            base.OnModelCreating (builder);
            builder.Entity<Team>().HasKey(t => new { t.Project, t.User });
        }

        public DbSet<User> users { get; set; }
        public DbSet<UserFunction> userFunction { get; set; }
        public DbSet<ProjectState> projectStates { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<ActivityType> activityType { get; set; }
        public DbSet<ActivityState> activityState { get; set; }
        public DbSet<FileContType> fileContType { get; set; }
        public DbSet<ExpenseState> expenseState { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Team> teams { get; set; }
    }
}
