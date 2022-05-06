using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_activityState",
                table: "activityState");

            migrationBuilder.RenameTable(
                name: "activityState",
                newName: "Activity State");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Activity State",
                table: "Activity State",
                column: "ActivityState_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Activity State",
                table: "Activity State");

            migrationBuilder.RenameTable(
                name: "Activity State",
                newName: "activityState");

            migrationBuilder.AddPrimaryKey(
                name: "PK_activityState",
                table: "activityState",
                column: "ActivityState_Id");
        }
    }
}
