using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AllGame",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 23, 19, 58, 22, 595, DateTimeKind.Local).AddTicks(7701),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 7, 23, 19, 52, 57, 857, DateTimeKind.Local).AddTicks(430));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AllGame",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 7, 23, 19, 52, 57, 857, DateTimeKind.Local).AddTicks(430),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 7, 23, 19, 58, 22, 595, DateTimeKind.Local).AddTicks(7701));
        }
    }
}
