using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllGame_SchemeMaster_SchemeMasterSchemeID",
                table: "AllGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AllGame_AllGameGameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Users_UserId",
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
                name: "SchemeMasterSchemeID",
                table: "AllGame");

            migrationBuilder.RenameTable(
                name: "SchemeMaster",
                schema: "dbo",
                newName: "SchemeMaster");

            migrationBuilder.RenameColumn(
                name: "SchemeId",
                table: "AllGame",
                newName: "SchemeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bet_GameId",
                schema: "dbo",
                table: "Bet",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_AllGame_SchemeID",
                table: "AllGame",
                column: "SchemeID");

            migrationBuilder.AddForeignKey(
                name: "FK_AllGame_SchemeMaster_SchemeID",
                table: "AllGame",
                column: "SchemeID",
                principalTable: "SchemeMaster",
                principalColumn: "SchemeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AllGame_GameId",
                schema: "dbo",
                table: "Bet",
                column: "GameId",
                principalTable: "AllGame",
                principalColumn: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Users_UserId",
                schema: "dbo",
                table: "Bet",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllGame_SchemeMaster_SchemeID",
                table: "AllGame");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AllGame_GameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropForeignKey(
                name: "FK_Bet_Users_UserId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_GameId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_AllGame_SchemeID",
                table: "AllGame");

            migrationBuilder.RenameTable(
                name: "SchemeMaster",
                newName: "SchemeMaster",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "SchemeID",
                table: "AllGame",
                newName: "SchemeId");

            migrationBuilder.AddColumn<long>(
                name: "AllGameGameId",
                schema: "dbo",
                table: "Bet",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchemeMasterSchemeID",
                table: "AllGame",
                type: "int",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_Users_UserId",
                schema: "dbo",
                table: "Bet",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
