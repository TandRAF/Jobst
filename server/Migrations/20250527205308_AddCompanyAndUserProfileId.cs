using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyAndUserProfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46140803-8956-4f32-9b71-63bd7667940e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6ca1004-75a0-4949-9ce4-b717b64f9f56");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CompanyProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2eaf941a-7b02-47c2-b040-035562b90e31", null, "Company", "COMPANY" },
                    { "57c086b8-13d8-43bf-b7c7-6c748523eac1", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CompanyProfileId",
                table: "AspNetUsers",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CompanyProfile_CompanyProfileId",
                table: "AspNetUsers",
                column: "CompanyProfileId",
                principalTable: "CompanyProfile",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfile_UserProfileId",
                table: "AspNetUsers",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CompanyProfile_CompanyProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfile_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CompanyProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2eaf941a-7b02-47c2-b040-035562b90e31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57c086b8-13d8-43bf-b7c7-6c748523eac1");

            migrationBuilder.DropColumn(
                name: "CompanyProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46140803-8956-4f32-9b71-63bd7667940e", null, "User", "USER" },
                    { "a6ca1004-75a0-4949-9ce4-b717b64f9f56", null, "Company", "COMPANY" }
                });
        }
    }
}
