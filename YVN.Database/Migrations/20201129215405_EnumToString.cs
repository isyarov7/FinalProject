using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace YVN.Database.Migrations
{
    public partial class EnumToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Visability",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e0ab4987-82b7-4d8f-be9c-15221ba4292a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "86f33ed7-108c-4371-96ce-e72f8a822d9c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "316d5207-fb1c-406a-8e1b-1c3f777c99f1", new DateTime(2020, 11, 29, 21, 54, 4, 565, DateTimeKind.Utc).AddTicks(7982), "AQAAAAEAACcQAAAAEH5ke0K7XI/6lj8BUrEvRGAwbETMJzOgwzrUNO8cEMyoJ2HGZq6YaWxq/ohhoaMVYQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Visability",
                table: "Posts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "073e826b-c376-4124-9e13-a0459efae87e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0f53abc6-a670-4d2e-b424-cdbd93eac7e7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "d8db33d7-ade7-4c9d-b82b-cf1fe1eaab72", new DateTime(2020, 11, 28, 21, 49, 48, 493, DateTimeKind.Utc).AddTicks(8818), "AQAAAAEAACcQAAAAENWWrTAlSwLBACz0NVpEfAhFlUwlv2GtbWuPlilQWN7IYL4LJ+iVbySjjFIWZBgBUg==" });
        }
    }
}
