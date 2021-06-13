using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erratas.Migrations
{
    public partial class _postModelAddedCategoryProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Posts",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "1fb44c9f-3f24-4941-8e2a-b6e5cefcb134");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fda445b5-6c2b-44f2-afdd-ef8c7922e742", "AQAAAAEAACcQAAAAEJw3u2FVI8AVf8wO7A9078XPsdOaLM+SjqOM0ywDDag3CJMmQ+KGJf7ZrbtjRJi0VA==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 12, 21, 2, 2, 880, DateTimeKind.Utc).AddTicks(7419));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 6, 12, 21, 2, 2, 881, DateTimeKind.Utc).AddTicks(215));
        }
    }
}
