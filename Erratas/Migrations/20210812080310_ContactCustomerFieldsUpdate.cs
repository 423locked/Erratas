using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erratas.Migrations
{
    public partial class ContactCustomerFieldsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                table: "ContactCustomers");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                table: "ContactCustomers");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                table: "ContactCustomers");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "ContactCustomers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ContactCustomers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "037d1e74-be47-4b41-b610-dca7632b97b1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2909a454-9152-4525-8c33-99d5e172c8e0", "AQAAAAEAACcQAAAAEPrFQxU+OihZwiNetqkAPpO4a2IuxAz6f/D5j88ZSiVSaP0y0t615Ofm2nEL1LCYdg==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 12, 8, 3, 10, 262, DateTimeKind.Utc).AddTicks(9605));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 12, 8, 3, 10, 263, DateTimeKind.Utc).AddTicks(2389));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                table: "ContactCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                table: "ContactCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                table: "ContactCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "ContactCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ContactCustomers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "237dc657-b8f5-4a5c-ac70-31b6a34f630d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "50e977aa-77e4-4b84-b5c3-aa4f0389cc25", "AQAAAAEAACcQAAAAEALibrXn4OwlizaUkbT8KyvKknaskQjalPeNKBO2M3rdhgCO0lJOH+YsqV+FmrzcsQ==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 12, 7, 56, 3, 575, DateTimeKind.Utc).AddTicks(4501));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 12, 7, 56, 3, 575, DateTimeKind.Utc).AddTicks(7139));
        }
    }
}
