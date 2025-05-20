using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class CvElements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc6fe964-6651-4070-a581-ff2c61511850");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "feb134e0-310a-4630-9895-35b6a71c143d");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Languages",
                newName: "LanguageName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c9ea48a-ebec-44a3-8088-82e11f6c4832", null, "User", "USER" },
                    { "b92fbe4e-b80d-48bc-a7df-0845d31f6cdc", null, "Company", "COMPANY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c9ea48a-ebec-44a3-8088-82e11f6c4832");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b92fbe4e-b80d-48bc-a7df-0845d31f6cdc");

            migrationBuilder.RenameColumn(
                name: "LanguageName",
                table: "Languages",
                newName: "Type");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "fc6fe964-6651-4070-a581-ff2c61511850", null, "User", "USER" },
                    { "feb134e0-310a-4630-9895-35b6a71c143d", null, "Company", "COMPANY" }
                });
        }
    }
}
