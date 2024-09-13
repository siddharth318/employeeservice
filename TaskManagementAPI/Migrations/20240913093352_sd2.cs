using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class sd2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId2",
                table: "trans");

            migrationBuilder.AddColumn<string>(
                name: "Title2",
                table: "trans",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title2",
                table: "trans");

            migrationBuilder.AddColumn<int>(
                name: "TaskId2",
                table: "trans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
