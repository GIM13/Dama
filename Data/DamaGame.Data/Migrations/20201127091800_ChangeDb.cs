namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Playgrounds");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games",
                column: "PlaygroundId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Playgrounds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games",
                column: "PlaygroundId",
                unique: true,
                filter: "[PlaygroundId] IS NOT NULL");
        }
    }
}
