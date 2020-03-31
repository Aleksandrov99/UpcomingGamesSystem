using Microsoft.EntityFrameworkCore.Migrations;

namespace UpcomingGamesSystem.Data.Migrations
{
    public partial class PictureUrlColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Games",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Games");
        }
    }
}
