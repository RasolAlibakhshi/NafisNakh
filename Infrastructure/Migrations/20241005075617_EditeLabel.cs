using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditeLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emptyfield5",
                table: "Labels",
                newName: "Yarn_Type");

            migrationBuilder.AddColumn<string>(
                name: "Mingle",
                table: "Labels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Warp_Direction",
                table: "Labels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mingle",
                table: "Labels");

            migrationBuilder.DropColumn(
                name: "Warp_Direction",
                table: "Labels");

            migrationBuilder.RenameColumn(
                name: "Yarn_Type",
                table: "Labels",
                newName: "Emptyfield5");
        }
    }
}
