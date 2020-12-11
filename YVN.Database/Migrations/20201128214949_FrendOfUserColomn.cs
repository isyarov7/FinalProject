using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace YVN.Database.Migrations
{
    public partial class FrendOfUserColomn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "Posts");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedOn",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "96406b01-1059-447b-a223-f2580542bb15");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "203d1e12-3b46-4003-bd44-9d514d3a2360");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash" },
                values: new object[] { "5706d144-8db8-47da-9261-b51eea5e2a3c", new DateTime(2020, 11, 27, 16, 26, 23, 259, DateTimeKind.Utc).AddTicks(1415), "AQAAAAEAACcQAAAAEDwH0+Y8yR1NR/Fa7xFhsqlgzf4QCvmtqjTViaAn8CQAgg0HQRBW4wZmd1An+4HAGA==" });
        }
    }
}
