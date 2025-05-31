using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddDatePostedToJobOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "414a5ff3-9761-4b7b-8e9a-6be125352739");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c65acc7-7a84-46de-9d7c-2778763cfd7b");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePosted",
                table: "JobOffer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d55f79c-e6ce-4d25-8176-48bf21bf577a", null, "User", "USER" },
                    { "d47c55ea-bbf4-412b-b8aa-7b6460086b34", null, "Company", "COMPANY" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d55f79c-e6ce-4d25-8176-48bf21bf577a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d47c55ea-bbf4-412b-b8aa-7b6460086b34");

            migrationBuilder.DropColumn(
                name: "DatePosted",
                table: "JobOffer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "414a5ff3-9761-4b7b-8e9a-6be125352739", null, "Company", "COMPANY" },
                    { "4c65acc7-7a84-46de-9d7c-2778763cfd7b", null, "User", "USER" }
                });
        }
    }
}
