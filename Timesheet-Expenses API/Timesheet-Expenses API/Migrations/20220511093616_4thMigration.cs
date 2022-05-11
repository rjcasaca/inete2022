using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _4thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Expenses_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Qtd_Line = table.Column<int>(type: "int", nullable: false),
                    ExpenseStateExpenseTypeId = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Project_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Expenses_Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Expense Type_ExpenseStateExpenseTypeId",
                        column: x => x.ExpenseStateExpenseTypeId,
                        principalTable: "Expense Type",
                        principalColumn: "ExpenseTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Project_Project_Id",
                        column: x => x.Project_Id,
                        principalTable: "Project",
                        principalColumn: "Project_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseStateExpenseTypeId",
                table: "Expenses",
                column: "ExpenseStateExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_Project_Id",
                table: "Expenses",
                column: "Project_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_User_Id",
                table: "Expenses",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");
        }
    }
}
