using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace serverSide.Migrations
{
    /// <inheritdoc />
    public partial class SADW : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_Departments_DepartmentId",
                table: "Faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "DepartmentAndHeads");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "Faculty");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Students",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                newName: "IX_Students_ProgramId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Faculty",
                newName: "ProgramId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculty_DepartmentId",
                table: "Faculty",
                newName: "IX_Faculty_ProgramId");

            migrationBuilder.CreateTable(
                name: "AcademicPrograms",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicPrograms", x => x.ProgramId);
                    table.ForeignKey(
                        name: "FK_AcademicPrograms_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicPrograms_FacultyId",
                table: "AcademicPrograms",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_AcademicPrograms_ProgramId",
                table: "Faculty",
                column: "ProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicPrograms_ProgramId",
                table: "Students",
                column: "ProgramId",
                principalTable: "AcademicPrograms",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_AcademicPrograms_ProgramId",
                table: "Faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicPrograms_ProgramId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "AcademicPrograms");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Students",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ProgramId",
                table: "Students",
                newName: "IX_Students_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "ProgramId",
                table: "Faculty",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Faculty_ProgramId",
                table: "Faculty",
                newName: "IX_Faculty_DepartmentId");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "Faculty",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentAndHeads",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentAndHeads", x => new { x.DepartmentId, x.FacultyId });
                    table.ForeignKey(
                        name: "FK_DepartmentAndHeads_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentAndHeads_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentAndHeads_FacultyId",
                table: "DepartmentAndHeads",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_Departments_DepartmentId",
                table: "Faculty",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
