using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeService.Migrations
{
    /// <inheritdoc />
    public partial class sid1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "newID",
                table: "employeess");

            migrationBuilder.AddColumn<string>(
                name: "Password2",
                table: "employeess",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password2",
                table: "employeess");

            migrationBuilder.AddColumn<int>(
                name: "newID",
                table: "employeess",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
