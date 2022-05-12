using Timesheet_Expenses_API.Models;
using Microsoft.EntityFrameworkCore;
using Timesheet_Expenses_API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Modified
//ConString Gabriel
builder.Services.AddDbContext<_DbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("GabrielConnection")));

//ConString Lucas
//builder.Services.AddDbContext<_DbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LucasConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserFunctionRepository, UserFunctionRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProjectStateRepository, ProjectStateRepository>();
builder.Services.AddScoped<IWorklogStateRepository, WorklogStateRepository>();
builder.Services.AddScoped<IBillingTypeRepository, BillingTypeRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<IWorklogRepository, WorklogRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
builder.Services.AddScoped<IActivityStateRepository, ActivityStateRepository>();
builder.Services.AddScoped<IActivity_FileRepository, Activity_FileRepository>();
builder.Services.AddScoped<ILineRepository, LineRepository>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
