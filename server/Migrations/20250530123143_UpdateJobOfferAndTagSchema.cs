using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobOfferAndTagSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_CompanyProfile_CompanyProfileId",
                table: "JobOffer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46140803-8956-4f32-9b71-63bd7667940e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6ca1004-75a0-4949-9ce4-b717b64f9f56");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobOffer");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "JobOffer",
                newName: "Tags");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyProfileId",
                table: "JobOffer",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyImageUrl",
                table: "JobOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyTitle",
                table: "JobOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "JobOffer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "JobOffer",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JobApplicationId",
                table: "CV",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyProfileId = table.Column<int>(type: "int", nullable: false),
                    JobOfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplication_CompanyProfile_CompanyProfileId",
                        column: x => x.CompanyProfileId,
                        principalTable: "CompanyProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "473ff979-0086-4f0b-9845-5e88029c70f0", null, "User", "USER" },
                    { "a789f907-00a0-4380-9f04-a84cdcd33245", null, "Company", "COMPANY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_TagId",
                table: "JobOffer",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_CV_JobApplicationId",
                table: "CV",
                column: "JobApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_CompanyProfileId",
                table: "JobApplication",
                column: "CompanyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobOfferId",
                table: "JobApplication",
                column: "JobOfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_CV_JobApplication_JobApplicationId",
                table: "CV",
                column: "JobApplicationId",
                principalTable: "JobApplication",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_CompanyProfile_CompanyProfileId",
                table: "JobOffer",
                column: "CompanyProfileId",
                principalTable: "CompanyProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_Tag_TagId",
                table: "JobOffer",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CV_JobApplication_JobApplicationId",
                table: "CV");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_CompanyProfile_CompanyProfileId",
                table: "JobOffer");

            migrationBuilder.DropForeignKey(
                name: "FK_JobOffer_Tag_TagId",
                table: "JobOffer");

            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_JobOffer_TagId",
                table: "JobOffer");

            migrationBuilder.DropIndex(
                name: "IX_CV_JobApplicationId",
                table: "CV");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "473ff979-0086-4f0b-9845-5e88029c70f0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a789f907-00a0-4380-9f04-a84cdcd33245");

            migrationBuilder.DropColumn(
                name: "CompanyImageUrl",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "CompanyTitle",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "JobOffer");

            migrationBuilder.DropColumn(
                name: "JobApplicationId",
                table: "CV");

            migrationBuilder.RenameColumn(
                name: "Tags",
                table: "JobOffer",
                newName: "Title");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyProfileId",
                table: "JobOffer",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobOffer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46140803-8956-4f32-9b71-63bd7667940e", null, "User", "USER" },
                    { "a6ca1004-75a0-4949-9ce4-b717b64f9f56", null, "Company", "COMPANY" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffer_CompanyProfile_CompanyProfileId",
                table: "JobOffer",
                column: "CompanyProfileId",
                principalTable: "CompanyProfile",
                principalColumn: "Id");
        }
    }
}
