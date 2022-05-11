using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheet_Expenses_API.Migrations
{
    public partial class _2thMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "File Content",
                columns: table => new
                {
                    FileContent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileContTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File Content", x => x.FileContent_Id);
                    table.ForeignKey(
                        name: "FK_File Content_FileCont Type_FileContTypeId",
                        column: x => x.FileContTypeId,
                        principalTable: "FileCont Type",
                        principalColumn: "FileContTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_File Content_FileContTypeId",
                table: "File Content",
                column: "FileContTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File Content");
        }
    }
}
