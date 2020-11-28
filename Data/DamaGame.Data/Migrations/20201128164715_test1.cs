namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_LeftPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_RightPlayerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Playgrounds_PlaygroundId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_LeftPlayerId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_RightPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "LeftPlayerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlaygroundId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RightPlayerId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "Playgrounds",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_GameId",
                table: "Playgrounds",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Games_GameId",
                table: "Playgrounds",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Games_GameId",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_GameId",
                table: "Playgrounds");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "Playgrounds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeftPlayerId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaygroundId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RightPlayerId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_LeftPlayerId",
                table: "Games",
                column: "LeftPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PlaygroundId",
                table: "Games",
                column: "PlaygroundId",
                unique: true,
                filter: "[PlaygroundId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RightPlayerId",
                table: "Games",
                column: "RightPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_LeftPlayerId",
                table: "Games",
                column: "LeftPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_RightPlayerId",
                table: "Games",
                column: "RightPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Playgrounds_PlaygroundId",
                table: "Games",
                column: "PlaygroundId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
