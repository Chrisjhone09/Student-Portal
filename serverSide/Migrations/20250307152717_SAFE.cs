using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class SAFE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEnrolledStudents",
                table: "DepartmentAndHeads");

            migrationBuilder.DropColumn(
                name: "NumberOfInstructors",
                table: "DepartmentAndHeads");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEnrolledStudents",
                table: "DepartmentAndHeads",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfInstructors",
                table: "DepartmentAndHeads",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
