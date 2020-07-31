using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetAmount",
                table: "AllTransaction");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AllTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AllTransaction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AllTransaction",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AllTransaction",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "BetId",
                table: "AllTransaction",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TransactionAmount",
                table: "AllTransaction",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionAmount",
                table: "AllTransaction");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AllTransaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TransactionTypeId",
                table: "AllTransaction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "IpAddress",
                table: "AllTransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AllTransaction",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<long>(
                name: "BetId",
                table: "AllTransaction",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<decimal>(
                name: "BetAmount",
                table: "AllTransaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
