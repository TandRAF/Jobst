using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UserBaseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eaf941a-7b02-47c2-b040-035562b90e31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57c086b8-13d8-43bf-b7c7-6c748523eac1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "347d7be7-0b45-4f48-8c25-7a4d711179fc", null, "User", "USER" },
                    { "fb6507c2-87b7-4052-9359-854ff849ad04", null, "Company", "COMPANY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "347d7be7-0b45-4f48-8c25-7a4d711179fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb6507c2-87b7-4052-9359-854ff849ad04");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2eaf941a-7b02-47c2-b040-035562b90e31", null, "Company", "COMPANY" },
                    { "57c086b8-13d8-43bf-b7c7-6c748523eac1", null, "User", "USER" }
                });
        }
    }
}
