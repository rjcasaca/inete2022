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
            builder.Entity<Team>().HasKey(t => new { t.ProjectId, t.UserId });
            builder.Entity<Activity_File>().HasKey(af => new { af.ActivityId, af.FileContentId });
            builder.Entity<Expense_File>().HasKey(ef => new { ef.FileContentId, ef.ExpenseId });
            builder.Entity<User_Activity>().HasKey(ua => new {ua.UserId, ua.ActivityId});
           
        }

        public DbSet<User> users { get; set; }
        public DbSet<WorklogState> worklogStates { get; set; }
        public DbSet<BillingType> billingTypes { get; set; }
        public DbSet<UserFunction> userFunction { get; set; }
        public DbSet<ProjectState> projectStates { get; set; }
        public DbSet<Client> client { get; set; }
        public DbSet<ActivityState> activityState { get; set; }
        public DbSet<ActivityType> activityType { get; set; }
        public DbSet<FileContentType> fileContType { get; set; }
        public DbSet<ExpenseType> expenseType { get; set; }
        public DbSet<ExpenseState> expenseState { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Team> teams { get; set; }
        public DbSet<Activity> activities { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Worklog> worklogs { get; set; }
        public DbSet<FileContent> fileContents { get; set; }
        public DbSet<Activity_File> activities_files { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<Expense_File> expenses_files { get; set; }
        public DbSet<Line> lines { get; set; }
        public DbSet<File> files { get; set; }
        public DbSet<User_Activity> activities_users { get; set; }
        public DbSet<LineType> lineType { get; set; }
        public DbSet<LineCity> lineCity { get; set; }
    }
}
