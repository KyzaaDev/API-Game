using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingDevName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DevName",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DevName",
                table: "Games");
        }
    }
}
