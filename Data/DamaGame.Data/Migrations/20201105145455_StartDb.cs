namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class StartDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_ApplicationUser",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ApplicationUser",
                table: "Players",
                column: "ApplicationUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_ApplicationUser",
                table: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_Players_ApplicationUser",
                table: "Players",
                column: "ApplicationUser",
                unique: true,
                filter: "[ApplicationUser] IS NOT NULL");
        }
    }
}
