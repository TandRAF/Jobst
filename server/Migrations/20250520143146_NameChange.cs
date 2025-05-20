using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_CV_CvId",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_CV_CvId",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c9ea48a-ebec-44a3-8088-82e11f6c4832");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b92fbe4e-b80d-48bc-a7df-0845d31f6cdc");

            migrationBuilder.RenameTable(
                name: "WorkExperiences",
                newName: "WorkExperience");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperiences_CvId",
                table: "WorkExperience",
                newName: "IX_WorkExperience_CvId");

            migrationBuilder.RenameIndex(
                name: "IX_Languages_CvId",
                table: "Language",
                newName: "IX_Language_CvId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "843b1c97-5994-401d-97dd-f6c914cce760", null, "User", "USER" },
                    { "9f9fd4e4-dd52-4ba9-8726-27d6912acf34", null, "Company", "COMPANY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Language_CV_CvId",
                table: "Language",
                column: "CvId",
                principalTable: "CV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_CV_CvId",
                table: "WorkExperience",
                column: "CvId",
                principalTable: "CV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Language_CV_CvId",
                table: "Language");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_CV_CvId",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkExperience",
                table: "WorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "843b1c97-5994-401d-97dd-f6c914cce760");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f9fd4e4-dd52-4ba9-8726-27d6912acf34");

            migrationBuilder.RenameTable(
                name: "WorkExperience",
                newName: "WorkExperiences");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.RenameIndex(
                name: "IX_WorkExperience_CvId",
                table: "WorkExperiences",
                newName: "IX_WorkExperiences_CvId");

            migrationBuilder.RenameIndex(
                name: "IX_Language_CvId",
                table: "Languages",
                newName: "IX_Languages_CvId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkExperiences",
                table: "WorkExperiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8c9ea48a-ebec-44a3-8088-82e11f6c4832", null, "User", "USER" },
                    { "b92fbe4e-b80d-48bc-a7df-0845d31f6cdc", null, "Company", "COMPANY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_CV_CvId",
                table: "Languages",
                column: "CvId",
                principalTable: "CV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_CV_CvId",
                table: "WorkExperiences",
                column: "CvId",
                principalTable: "CV",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
