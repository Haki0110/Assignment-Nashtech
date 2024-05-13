using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameworkAssignment1.Migrations
{
    /// <inheritdoc />
    public partial class AddProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Projects",
            columns: new[] { "Id", "Name" },
            values: new object[] { 5, "Project 5" });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5); 
        }
    }
}
