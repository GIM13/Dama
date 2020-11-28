namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeFromUserToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_ApplicationUser",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "Players",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ApplicationUser",
                table: "Players",
                newName: "IX_Players_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_ApplicationUserId",
                table: "Players",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_AspNetUsers_ApplicationUserId",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Players",
                newName: "ApplicationUser");

            migrationBuilder.RenameIndex(
                name: "IX_Players_ApplicationUserId",
                table: "Players",
                newName: "IX_Players_ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_AspNetUsers_ApplicationUser",
                table: "Players",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
