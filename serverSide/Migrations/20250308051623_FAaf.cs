using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class FAaf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicPrograms_Faculty_FacultyId",
                table: "AcademicPrograms");

            migrationBuilder.DropIndex(
                name: "IX_AcademicPrograms_FacultyId",
                table: "AcademicPrograms");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "AcademicPrograms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "AcademicPrograms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_FacultyId",
                table: "AcademicPrograms",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicPrograms_Faculty_FacultyId",
                table: "AcademicPrograms",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
