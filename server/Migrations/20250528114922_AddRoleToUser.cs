using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "02c07e4c-f808-4ecb-b644-a537dd90184a", null, "User", "USER" },
                    { "4f78faed-9fa9-45f2-9fb2-9008e4f31ab7", null, "Company", "COMPANY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02c07e4c-f808-4ecb-b644-a537dd90184a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f78faed-9fa9-45f2-9fb2-9008e4f31ab7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "347d7be7-0b45-4f48-8c25-7a4d711179fc", null, "User", "USER" },
                    { "fb6507c2-87b7-4052-9359-854ff849ad04", null, "Company", "COMPANY" }
                });
        }
    }
}
