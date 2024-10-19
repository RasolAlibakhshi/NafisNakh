using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionPackaging : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HallID",
                table: "OptionInPackaging",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OptionInPackaging_HallID",
                table: "OptionInPackaging",
                column: "HallID");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionInPackaging_Halls_HallID",
                table: "OptionInPackaging",
                column: "HallID",
                principalTable: "Halls",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionInPackaging_Halls_HallID",
                table: "OptionInPackaging");

            migrationBuilder.DropIndex(
                name: "IX_OptionInPackaging_HallID",
                table: "OptionInPackaging");

            migrationBuilder.DropColumn(
                name: "HallID",
                table: "OptionInPackaging");
        }
    }
}
