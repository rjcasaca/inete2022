using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _1thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity State",
                columns: table => new
                {
                    ActivityState_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity State", x => x.ActivityState_Id);
                });

            migrationBuilder.CreateTable(
                name: "Activity Type",
                columns: table => new
                {
                    ActivityType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity Type", x => x.ActivityType_Id);
                });

            migrationBuilder.CreateTable(
                name: "ArquiUsers",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArquiUsers", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Billing Type",
                columns: table => new
                {
                    BillingType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billing Type", x => x.BillingType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Client_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Client_Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense State",
                columns: table => new
                {
                    ExpenseState_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense State", x => x.ExpenseState_Id);
                });

            migrationBuilder.CreateTable(
                name: "Expense Type",
                columns: table => new
                {
                    ExpenseType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense Type", x => x.ExpenseType_Id);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    File_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    base64 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.File_Id);
                });

            migrationBuilder.CreateTable(
                name: "File Content Type",
                columns: table => new
                {
                    FileContentType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File Content Type", x => x.FileContentType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Project State",
                columns: table => new
                {
                    ProjectState_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project State", x => x.ProjectState_Id);
                });

            migrationBuilder.CreateTable(
                name: "User Function",
                columns: table => new
                {
                    UserFunction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Function = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User Function", x => x.UserFunction_Id);
                });

            migrationBuilder.CreateTable(
                name: "Worklog State",
                columns: table => new
                {
                    WorklogState_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worklog State", x => x.WorklogState_Id);
                });

            migrationBuilder.CreateTable(
                name: "File Content",
                columns: table => new
                {
                    FileContent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileContentType_Id = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File Content", x => x.FileContent_Id);
                    table.ForeignKey(
                        name: "FK_File Content_File Content Type_FileContentType_Id",
                        column: x => x.FileContentType_Id,
                        principalTable: "File Content Type",
                        principalColumn: "FileContentType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File Content_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "File_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Project_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Client_Id = table.Column<int>(type: "int", nullable: false),
                    ProjectState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Project_Id);
                    table.ForeignKey(
                        name: "FK_Project_Client_Client_Id",
                        column: x => x.Client_Id,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Project State_ProjectState_Id",
                        column: x => x.ProjectState_Id,
                        principalTable: "Project State",
                        principalColumn: "ProjectState_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Activity_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Project_Id = table.Column<int>(type: "int", nullable: false),
                    ActivityState_Id = table.Column<int>(type: "int", nullable: false),
                    ActivityType_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Activity_Id);
                    table.ForeignKey(
                        name: "FK_Activity_Activity State_ActivityState_Id",
                        column: x => x.ActivityState_Id,
                        principalTable: "Activity State",
                        principalColumn: "ActivityState_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Activity Type_ActivityType_Id",
                        column: x => x.ActivityType_Id,
                        principalTable: "Activity Type",
                        principalColumn: "ActivityType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Project_Project_Id",
                        column: x => x.Project_Id,
                        principalTable: "Project",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense",
                columns: table => new
                {
                    Expense_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qtd_Line = table.Column<int>(type: "int", nullable: false),
                    ExpenseType_Id = table.Column<int>(type: "int", nullable: false),
                    ExpenseState_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Project_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Expense_Id);
                    table.ForeignKey(
                        name: "FK_Expense_ArquiUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Expense State_ExpenseState_Id",
                        column: x => x.ExpenseState_Id,
                        principalTable: "Expense State",
                        principalColumn: "ExpenseState_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Expense Type_ExpenseType_Id",
                        column: x => x.ExpenseType_Id,
                        principalTable: "Expense Type",
                        principalColumn: "ExpenseType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Project_Project_Id",
                        column: x => x.Project_Id,
                        principalTable: "Project",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserFunction_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => new { x.ProjectId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Team_ArquiUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_User Function_UserFunction_Id",
                        column: x => x.UserFunction_Id,
                        principalTable: "User Function",
                        principalColumn: "UserFunction_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activity_File",
                columns: table => new
                {
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    FileContentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_File", x => new { x.ActivityId, x.FileContentId });
                    table.ForeignKey(
                        name: "FK_Activity_File_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Activity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_File_File Content_FileContentId",
                        column: x => x.FileContentId,
                        principalTable: "File Content",
                        principalColumn: "FileContent_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activity_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_Comment_Activity_Activity_Id",
                        column: x => x.Activity_Id,
                        principalTable: "Activity",
                        principalColumn: "Activity_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Activity",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Activity", x => new { x.UserId, x.ActivityId });
                    table.ForeignKey(
                        name: "FK_User_Activity_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Activity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Activity_ArquiUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Worklog",
                columns: table => new
                {
                    Cod_Worklog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Activity_Id = table.Column<int>(type: "int", nullable: false),
                    BillingType_Id = table.Column<int>(type: "int", nullable: false),
                    WorklogState_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worklog", x => x.Cod_Worklog);
                    table.ForeignKey(
                        name: "FK_Worklog_Activity_Activity_Id",
                        column: x => x.Activity_Id,
                        principalTable: "Activity",
                        principalColumn: "Activity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_ArquiUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_Billing Type_BillingType_Id",
                        column: x => x.BillingType_Id,
                        principalTable: "Billing Type",
                        principalColumn: "BillingType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_Worklog State_WorklogState_Id",
                        column: x => x.WorklogState_Id,
                        principalTable: "Worklog State",
                        principalColumn: "WorklogState_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expense_File",
                columns: table => new
                {
                    FileContentId = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense_File", x => new { x.FileContentId, x.ExpenseId });
                    table.ForeignKey(
                        name: "FK_Expense_File_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Expense_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_File_File Content_FileContentId",
                        column: x => x.FileContentId,
                        principalTable: "File Content",
                        principalColumn: "FileContent_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Cod_Line = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnityPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Expense_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Cod_Line);
                    table.ForeignKey(
                        name: "FK_Line_Expense_Expense_Id",
                        column: x => x.Expense_Id,
                        principalTable: "Expense",
                        principalColumn: "Expense_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityState_Id",
                table: "Activity",
                column: "ActivityState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityType_Id",
                table: "Activity",
                column: "ActivityType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Project_Id",
                table: "Activity",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_File_FileContentId",
                table: "Activity_File",
                column: "FileContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Activity_Id",
                table: "Comment",
                column: "Activity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseState_Id",
                table: "Expense",
                column: "ExpenseState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseType_Id",
                table: "Expense",
                column: "ExpenseType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_Project_Id",
                table: "Expense",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_User_Id",
                table: "Expense",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_File_ExpenseId",
                table: "Expense_File",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_File Content_FileContentType_Id",
                table: "File Content",
                column: "FileContentType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_File Content_FileId",
                table: "File Content",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Line_Expense_Id",
                table: "Line",
                column: "Expense_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Client_Id",
                table: "Project",
                column: "Client_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectState_Id",
                table: "Project",
                column: "ProjectState_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserFunction_Id",
                table: "Team",
                column: "UserFunction_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Activity_ActivityId",
                table: "User_Activity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_Activity_Id",
                table: "Worklog",
                column: "Activity_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_BillingType_Id",
                table: "Worklog",
                column: "BillingType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_User_Id",
                table: "Worklog",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_WorklogState_Id",
                table: "Worklog",
                column: "WorklogState_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_File");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Expense_File");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "User_Activity");

            migrationBuilder.DropTable(
                name: "Worklog");

            migrationBuilder.DropTable(
                name: "File Content");

            migrationBuilder.DropTable(
                name: "Expense");

            migrationBuilder.DropTable(
                name: "User Function");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Billing Type");

            migrationBuilder.DropTable(
                name: "Worklog State");

            migrationBuilder.DropTable(
                name: "File Content Type");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "ArquiUsers");

            migrationBuilder.DropTable(
                name: "Expense State");

            migrationBuilder.DropTable(
                name: "Expense Type");

            migrationBuilder.DropTable(
                name: "Activity State");

            migrationBuilder.DropTable(
                name: "Activity Type");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Project State");
        }
    }
}
