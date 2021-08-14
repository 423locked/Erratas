using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erratas.Migrations
{
    public partial class UserLikedPostsTableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLikedPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ListOfPosts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikedPosts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                column: "ConcurrencyStamp",
                value: "ed47bfe1-cf90-4e86-9264-5f5553259890");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9c0f2fc-f03d-4d70-8a44-d8939d3f151b", "AQAAAAEAACcQAAAAEFB2ouZkxVX+TYAnOnBXxIeDl//631YZ1Xrejb/92OHjWIBImt87kj2bHALtX7CaBw==" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 14, 18, 54, 3, 841, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                column: "DateAdded",
                value: new DateTime(2021, 8, 14, 18, 54, 3, 842, DateTimeKind.Utc).AddTicks(9));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikedPosts");

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
    }
}
