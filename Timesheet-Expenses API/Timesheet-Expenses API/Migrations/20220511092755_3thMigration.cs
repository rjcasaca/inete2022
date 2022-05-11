using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _3thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Activity_File_FileContentId",
                table: "Activity_File",
                column: "FileContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity_File");
        }
    }
}
