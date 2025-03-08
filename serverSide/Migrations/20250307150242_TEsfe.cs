using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class TEsfe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEnrolledStudents",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "NumberOfInstructors",
                table: "Departments");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfEnrolledStudents",
                table: "DepartmentAndHeads");

            migrationBuilder.DropColumn(
                name: "NumberOfInstructors",
                table: "DepartmentAndHeads");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfEnrolledStudents",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfInstructors",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
