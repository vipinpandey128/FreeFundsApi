using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllTransaction_Bet_BetId",
                table: "AllTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AllTransaction_BetId",
                table: "AllTransaction");

            migrationBuilder.DropColumn(
                name: "BetId",
                table: "AllTransaction");

            migrationBuilder.AddColumn<long>(
                name: "AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RecordId",
                table: "AllTransaction",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Bet_AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet",
                column: "AllTransactionsTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bet_AllTransaction_AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet",
                column: "AllTransactionsTransactionId",
                principalTable: "AllTransaction",
                principalColumn: "TransactionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bet_AllTransaction_AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropIndex(
                name: "IX_Bet_AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "AllTransactionsTransactionId",
                schema: "dbo",
                table: "Bet");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "AllTransaction");

            migrationBuilder.AddColumn<long>(
                name: "BetId",
                table: "AllTransaction",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_AllTransaction_BetId",
                table: "AllTransaction",
                column: "BetId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllTransaction_Bet_BetId",
                table: "AllTransaction",
                column: "BetId",
                principalSchema: "dbo",
                principalTable: "Bet",
                principalColumn: "BetId");
        }
    }
}
