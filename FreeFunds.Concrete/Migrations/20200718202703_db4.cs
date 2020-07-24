using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchemeID",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.AddColumn<long>(
                name: "AllGameGameId",
                schema: "dbo",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                schema: "dbo",
                table: "Bet",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "SchemeMasterSchemeID",
                table: "AllGame",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_AllGameGameId",
                schema: "dbo",
                table: "Bet",
                column: "AllGameGameId");

            migrationBuilder.CreateIndex(
                name: "IX_AllGame_SchemeMasterSchemeID",
                table: "AllGame",
                column: "SchemeMasterSchemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllGame_SchemeMaster_SchemeMasterSchemeID",
                table: "AllGame",
                column: "SchemeMasterSchemeID",
                principalSchema: "dbo",
                principalTable: "SchemeMaster",
                principalColumn: "SchemeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AllGame_AllGameGameId",
                schema: "dbo",
                table: "Bet",
                column: "AllGameGameId",
                principalTable: "AllGame",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllGame_SchemeMaster_SchemeMasterSchemeID",
                table: "AllGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AllGame_AllGameGameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_AllGameGameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_AllGame_SchemeMasterSchemeID",
                table: "AllGame");

            migrationBuilder.DropColumn(
                name: "AllGameGameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "GameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "SchemeMasterSchemeID",
                table: "AllGame");

            migrationBuilder.AddColumn<int>(
                name: "SchemeID",
                schema: "dbo",
                table: "Bet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
