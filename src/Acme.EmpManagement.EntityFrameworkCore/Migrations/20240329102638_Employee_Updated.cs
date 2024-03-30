using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.EmpManagement.Migrations
{
    /// <inheritdoc />
    public partial class Employee_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "AppEmployees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "AppEmployees");
        }
    }
}
