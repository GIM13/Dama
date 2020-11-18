namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGameTheDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Game_Playground",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_Playground",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "Playground",
                table: "Playgrounds");

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Playgrounds",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaygroundId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlaygroundId",
                table: "Game",
                column: "PlaygroundId",
                unique: true,
                filter: "[PlaygroundId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Playgrounds_PlaygroundId",
                table: "Game",
                column: "PlaygroundId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Playgrounds_PlaygroundId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlaygroundId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "PlaygroundId",
                table: "Game");

            migrationBuilder.AddColumn<string>(
                name: "Playground",
                table: "Playgrounds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_Playground",
                table: "Playgrounds",
                column: "Playground",
                unique: true,
                filter: "[Playground] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Game_Playground",
                table: "Playgrounds",
                column: "Playground",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
