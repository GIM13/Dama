namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PlayerWithNewPropertyWaiting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pawns_Games_GameId",
                table: "Pawns");

            migrationBuilder.DropForeignKey(
                name: "FK_Pawns_Games_GameId1",
                table: "Pawns");

            migrationBuilder.DropIndex(
                name: "IX_Pawns_GameId",
                table: "Pawns");

            migrationBuilder.DropIndex(
                name: "IX_Pawns_GameId1",
                table: "Pawns");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Pawns");

            migrationBuilder.DropColumn(
                name: "GameId1",
                table: "Pawns");

            migrationBuilder.AddColumn<bool>(
                name: "Waiting",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Waiting",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Pawns",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameId1",
                table: "Pawns",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_GameId",
                table: "Pawns",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_GameId1",
                table: "Pawns",
                column: "GameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pawns_Games_GameId",
                table: "Pawns",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pawns_Games_GameId1",
                table: "Pawns",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
