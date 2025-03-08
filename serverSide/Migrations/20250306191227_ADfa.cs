using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class ADfa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentAndHead_Departments_DepartmentId",
                table: "DepartmentAndHead");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentAndHead_Faculty_FacultyId",
                table: "DepartmentAndHead");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentAndHead",
                table: "DepartmentAndHead");

            migrationBuilder.RenameTable(
                name: "DepartmentAndHead",
                newName: "DepartmentAndHeads");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentAndHead_FacultyId",
                table: "DepartmentAndHeads",
                newName: "IX_DepartmentAndHeads_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentAndHeads",
                table: "DepartmentAndHeads",
                columns: new[] { "DepartmentId", "FacultyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentAndHeads_Departments_DepartmentId",
                table: "DepartmentAndHeads",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentAndHeads_Faculty_FacultyId",
                table: "DepartmentAndHeads",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentAndHeads_Departments_DepartmentId",
                table: "DepartmentAndHeads");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentAndHeads_Faculty_FacultyId",
                table: "DepartmentAndHeads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentAndHeads",
                table: "DepartmentAndHeads");

            migrationBuilder.RenameTable(
                name: "DepartmentAndHeads",
                newName: "DepartmentAndHead");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentAndHeads_FacultyId",
                table: "DepartmentAndHead",
                newName: "IX_DepartmentAndHead_FacultyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentAndHead",
                table: "DepartmentAndHead",
                columns: new[] { "DepartmentId", "FacultyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentAndHead_Departments_DepartmentId",
                table: "DepartmentAndHead",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentAndHead_Faculty_FacultyId",
                table: "DepartmentAndHead",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
