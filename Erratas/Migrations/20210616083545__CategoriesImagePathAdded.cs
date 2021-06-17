using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erratas.Migrations
{
    public partial class _CategoriesImagePathAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TitleImagePath",
                table: "Categories",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "ca6d0aa2-7734-4abd-a72f-34af2c0603e9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0d0c579c-a4fc-470b-b341-dd9bbcbf6e61", "AQAAAAEAACcQAAAAEKxODHUEZuof0r6gFJbLYdr3XcKh1Cd62pqGtgv377d4ddg17KqnL7NdJAAD6fJiMA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 16, 8, 35, 44, 676, DateTimeKind.Utc).AddTicks(9850));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 16, 8, 35, 44, 677, DateTimeKind.Utc).AddTicks(2659));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleImagePath",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "4a5a392f-3d58-4395-a4bc-c72db12d14bd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71935494-a7de-4f4b-bd47-f3bff2cba019", "AQAAAAEAACcQAAAAEE9X3B5dXLg96PmioTEiyCChPx70F9M51wgIId8xsvhrCp67br2Y/GYyDAbsdTJ2QQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 12, 21, 39, 11, 871, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 12, 21, 39, 11, 871, DateTimeKind.Utc).AddTicks(7816));
        }
    }
}
