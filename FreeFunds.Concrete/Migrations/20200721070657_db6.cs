using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "WinPer",
                schema: "dbo",
                table: "Bet",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WinPer",
                table: "SchemeMaster",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinPer",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "WinPer",
                table: "SchemeMaster");
        }
    }
}
