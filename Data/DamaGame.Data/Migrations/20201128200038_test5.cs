namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class Test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pawns_Players_PlayerId",
                table: "Pawns");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Pawns",
                newName: "GameId1");

            migrationBuilder.RenameIndex(
                name: "IX_Pawns_PlayerId",
                table: "Pawns",
                newName: "IX_Pawns_GameId1");

            migrationBuilder.AddColumn<string>(
                name: "PawnId",
                table: "Players",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameId",
                table: "Pawns",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Players_PawnId",
                table: "Players",
                column: "PawnId");

            migrationBuilder.CreateIndex(
                name: "IX_Pawns_GameId",
                table: "Pawns",
                column: "GameId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Pawns_PawnId",
                table: "Players",
                column: "PawnId",
                principalTable: "Pawns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pawns_Games_GameId",
                table: "Pawns");

            migrationBuilder.DropForeignKey(
                name: "FK_Pawns_Games_GameId1",
                table: "Pawns");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Pawns_PawnId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PawnId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Pawns_GameId",
                table: "Pawns");

            migrationBuilder.DropColumn(
                name: "PawnId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Pawns");

            migrationBuilder.RenameColumn(
                name: "GameId1",
                table: "Pawns",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Pawns_GameId1",
                table: "Pawns",
                newName: "IX_Pawns_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pawns_Players_PlayerId",
                table: "Pawns",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
