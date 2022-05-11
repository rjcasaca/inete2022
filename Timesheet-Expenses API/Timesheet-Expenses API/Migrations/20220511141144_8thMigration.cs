using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _8thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worklog_Biling Type_BilingType_Id",
                table: "Worklog");

            migrationBuilder.DropTable(
                name: "Biling Type");

            migrationBuilder.RenameColumn(
                name: "BilingType_Id",
                table: "Worklog",
                newName: "BillingType_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Worklog_BilingType_Id",
                table: "Worklog",
                newName: "IX_Worklog_BillingType_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Worklog_Billing Type_BillingType_Id",
                table: "Worklog",
                column: "BillingType_Id",
                principalTable: "Billing Type",
                principalColumn: "BillingType_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Worklog_Billing Type_BillingType_Id",
                table: "Worklog");

            migrationBuilder.DropTable(
                name: "Billing Type");

            migrationBuilder.RenameColumn(
                name: "BillingType_Id",
                table: "Worklog",
                newName: "BilingType_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Worklog_BillingType_Id",
                table: "Worklog",
                newName: "IX_Worklog_BilingType_Id");

            migrationBuilder.CreateTable(
                name: "Biling Type",
                columns: table => new
                {
                    BilingType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biling Type", x => x.BilingType_Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Worklog_Biling Type_BilingType_Id",
                table: "Worklog",
                column: "BilingType_Id",
                principalTable: "Biling Type",
                principalColumn: "BilingType_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
