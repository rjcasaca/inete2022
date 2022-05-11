using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _6thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expense_File",
                columns: table => new
                {
                    FileContentId = table.Column<int>(type: "int", nullable: false),
                    ExpensesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expense_File", x => new { x.FileContentId, x.ExpensesId });
                    table.ForeignKey(
                        name: "FK_Expense_File_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Expenses_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expense_File_File Content_FileContentId",
                        column: x => x.FileContentId,
                        principalTable: "File Content",
                        principalColumn: "FileContent_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expense_File_ExpensesId",
                table: "Expense_File",
                column: "ExpensesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expense_File");
        }
    }
}
