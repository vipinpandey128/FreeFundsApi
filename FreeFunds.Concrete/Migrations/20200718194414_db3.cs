using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AllTransaction",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_AllTransaction_TransactionTypeId",
                table: "AllTransaction",
                column: "TransactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllTransaction_TransactionType_TransactionTypeId",
                table: "AllTransaction",
                column: "TransactionTypeId",
                principalSchema: "dbo",
                principalTable: "TransactionType",
                principalColumn: "TransationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllTransaction_TransactionType_TransactionTypeId",
                table: "AllTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AllTransaction_TransactionTypeId",
                table: "AllTransaction");

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AllTransaction",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
