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
                    base64 = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "LineCity",
                columns: table => new
                {
                    LineCityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineCity", x => x.LineCityID);
                });

            migrationBuilder.CreateTable(
                name: "LineType",
                columns: table => new
                {
                    LineTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineType", x => x.LineTypeID);
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
                    FileContentTypeId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File Content", x => x.FileContent_Id);
                    table.ForeignKey(
                        name: "FK_File Content_File Content Type_FileContentTypeId",
                        column: x => x.FileContentTypeId,
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
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ProjectStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Project_Id);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Client_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Project State_ProjectStateId",
                        column: x => x.ProjectStateId,
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
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ActivityStateId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Activity_Id);
                    table.ForeignKey(
                        name: "FK_Activity_Activity State_ActivityStateId",
                        column: x => x.ActivityStateId,
                        principalTable: "Activity State",
                        principalColumn: "ActivityState_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Activity Type_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "Activity Type",
                        principalColumn: "ActivityType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_Project_ProjectId",
                        column: x => x.ProjectId,
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
                    Expense_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    ExpenseStateId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense", x => x.Expense_Id);
                    table.ForeignKey(
                        name: "FK_Expense_ArquiUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Expense State_ExpenseStateId",
                        column: x => x.ExpenseStateId,
                        principalTable: "Expense State",
                        principalColumn: "ExpenseState_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Expense Type_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "Expense Type",
                        principalColumn: "ExpenseType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_Project_ProjectId",
                        column: x => x.ProjectId,
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
                    UserFunctionId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Team_User Function_UserFunctionId",
                        column: x => x.UserFunctionId,
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    BillingTypeId = table.Column<int>(type: "int", nullable: false),
                    WorklogStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worklog", x => x.Cod_Worklog);
                    table.ForeignKey(
                        name: "FK_Worklog_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Activity_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_ArquiUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ArquiUsers",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_Billing Type_BillingTypeId",
                        column: x => x.BillingTypeId,
                        principalTable: "Billing Type",
                        principalColumn: "BillingType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Worklog_Worklog State_WorklogStateId",
                        column: x => x.WorklogStateId,
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
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    period = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    lineCIty = table.Column<int>(type: "int", nullable: false),
                    lineType = table.Column<int>(type: "int", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    LineCityID = table.Column<int>(type: "int", nullable: true),
                    LineTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Cod_Line);
                    table.ForeignKey(
                        name: "FK_Line_Expense_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expense",
                        principalColumn: "Expense_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Line_LineCity_LineCityID",
                        column: x => x.LineCityID,
                        principalTable: "LineCity",
                        principalColumn: "LineCityID");
                    table.ForeignKey(
                        name: "FK_Line_LineType_LineTypeID",
                        column: x => x.LineTypeID,
                        principalTable: "LineType",
                        principalColumn: "LineTypeID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityStateId",
                table: "Activity",
                column: "ActivityStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityTypeId",
                table: "Activity",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ProjectId",
                table: "Activity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_File_FileContentId",
                table: "Activity_File",
                column: "FileContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseStateId",
                table: "Expense",
                column: "ExpenseStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ExpenseTypeId",
                table: "Expense",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_ProjectId",
                table: "Expense",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_UserId",
                table: "Expense",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expense_File_ExpenseId",
                table: "Expense_File",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_File Content_FileContentTypeId",
                table: "File Content",
                column: "FileContentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_File Content_FileId",
                table: "File Content",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_ExpenseId",
                table: "Line",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_Line_LineCityID",
                table: "Line",
                column: "LineCityID");

            migrationBuilder.CreateIndex(
                name: "IX_Line_LineTypeID",
                table: "Line",
                column: "LineTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStateId",
                table: "Project",
                column: "ProjectStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserFunctionId",
                table: "Team",
                column: "UserFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UserId",
                table: "Team",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Activity_ActivityId",
                table: "User_Activity",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_ActivityId",
                table: "Worklog",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_BillingTypeId",
                table: "Worklog",
                column: "BillingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_UserId",
                table: "Worklog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Worklog_WorklogStateId",
                table: "Worklog",
                column: "WorklogStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_File");

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
                name: "LineCity");

            migrationBuilder.DropTable(
                name: "LineType");

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
