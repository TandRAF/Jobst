using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class MakeCompanyImageUrlNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "473ff979-0086-4f0b-9845-5e88029c70f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a789f907-00a0-4380-9f04-a84cdcd33245");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "414a5ff3-9761-4b7b-8e9a-6be125352739", null, "Company", "COMPANY" },
                    { "4c65acc7-7a84-46de-9d7c-2778763cfd7b", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "414a5ff3-9761-4b7b-8e9a-6be125352739");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c65acc7-7a84-46de-9d7c-2778763cfd7b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "473ff979-0086-4f0b-9845-5e88029c70f0", null, "User", "USER" },
                    { "a789f907-00a0-4380-9f04-a84cdcd33245", null, "Company", "COMPANY" }
                });
        }
    }
}
