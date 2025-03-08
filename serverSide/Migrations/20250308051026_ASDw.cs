using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class ASDw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeadName",
                table: "AcademicPrograms",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadName",
                table: "AcademicPrograms");
        }
    }
}
