namespace DamaGame.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddGameTheDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Players_LeftPlayerId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Players_RightPlayerId",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_LeftPlayerId",
                table: "Playgrounds");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_RightPlayerId",
                table: "Playgrounds");

            migrationBuilder.DropColumn(
                name: "LeftPlayerId",
                table: "Playgrounds");

            migrationBuilder.RenameColumn(
                name: "RightPlayerId",
                table: "Playgrounds",
                newName: "Playground");

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LeftPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RightPlayerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Players_LeftPlayerId",
                        column: x => x.LeftPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Game_Players_RightPlayerId",
                        column: x => x.RightPlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_Playground",
                table: "Playgrounds",
                column: "Playground",
                unique: true,
                filter: "[Playground] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Game_IsDeleted",
                table: "Game",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Game_LeftPlayerId",
                table: "Game",
                column: "LeftPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_RightPlayerId",
                table: "Game",
                column: "RightPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Game_Playground",
                table: "Playgrounds",
                column: "Playground",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Game_Playground",
                table: "Playgrounds");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Playgrounds_Playground",
                table: "Playgrounds");

            migrationBuilder.RenameColumn(
                name: "Playground",
                table: "Playgrounds",
                newName: "RightPlayerId");

            migrationBuilder.AddColumn<string>(
                name: "LeftPlayerId",
                table: "Playgrounds",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_LeftPlayerId",
                table: "Playgrounds",
                column: "LeftPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_RightPlayerId",
                table: "Playgrounds",
                column: "RightPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Players_LeftPlayerId",
                table: "Playgrounds",
                column: "LeftPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Playgrounds_Players_RightPlayerId",
                table: "Playgrounds",
                column: "RightPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
