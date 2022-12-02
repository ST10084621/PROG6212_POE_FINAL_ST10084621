using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POE_FINAL_PROG6212.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoursWorked = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noOfCredits = table.Column<int>(type: "int", nullable: false),
                    classHoursPerWeek = table.Column<int>(type: "int", nullable: false),
                    remaininghours = table.Column<int>(type: "int", nullable: false),
                    selfStudyHours = table.Column<double>(type: "float", nullable: false),
                    semNoOfWeeks = table.Column<int>(type: "int", nullable: false),
                    studentID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.ModuleId);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    semesterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noOfWeeks = table.Column<int>(type: "int", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    studentID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DropTable(
                name: "Semester");
        }
    }
}
