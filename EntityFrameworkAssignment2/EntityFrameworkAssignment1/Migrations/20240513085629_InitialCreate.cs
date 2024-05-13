using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployees",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployees", x => new { x.ProjectId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Software Development" },
                    { 2, "Finance" },
                    { 3, "Accountant" },
                    { 4, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Project 1" },
                    { 2, "Project 2" },
                    { 3, "Project 3" },
                    { 4, "Project 4" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DepartmentId", "JoinedDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4300), "John Doe" },
                    { 2, 2, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4312), "Jane Smith" },
                    { 3, 1, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4313), "Michael Johnson" },
                    { 4, 3, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4315), "Emily Brown" },
                    { 5, 2, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4316), "David Wilson" },
                    { 6, 1, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4317), "Jessica Lee" },
                    { 7, 4, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4318), "Christopher Davis" },
                    { 8, 3, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4320), "Ashley Martinez" },
                    { 9, 2, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4321), "Matthew Taylor" },
                    { 10, 4, new DateTime(2024, 5, 13, 15, 56, 28, 296, DateTimeKind.Local).AddTicks(4322), "Amanda Harris" }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId", "Enabled" },
                values: new object[,]
                {
                    { 1, 1, true },
                    { 3, 1, true },
                    { 6, 1, true },
                    { 2, 2, true },
                    { 5, 2, true },
                    { 9, 2, true },
                    { 4, 3, true },
                    { 8, 3, true },
                    { 7, 4, true },
                    { 10, 4, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployees_EmployeeId",
                table: "ProjectEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectEmployees");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
