using Microsoft.EntityFrameworkCore.Migrations;

namespace DamaGame.Data.Migrations
{
    public partial class AddBusyToPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "Positions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "Players",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "Players");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 2);
        }
    }
}
