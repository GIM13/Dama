namespace DamaGame.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class PlayerWithNewPropertyStatePlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Waiting",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "StatePlayer",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatePlayer",
                table: "Players");

            migrationBuilder.AddColumn<bool>(
                name: "Waiting",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
