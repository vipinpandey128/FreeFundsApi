﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FreeFundsApi.Concrete.Migrations
{
    public partial class db8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "AllGame");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "AllGame");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "AllGame",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "AllGame");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "AllGame",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "AllGame",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
