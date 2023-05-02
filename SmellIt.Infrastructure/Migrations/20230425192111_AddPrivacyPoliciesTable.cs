using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class AddPrivacyPoliciesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebsiteTextTranslations_WebsiteTexts_LayoutTextId",
                table: "WebsiteTextTranslations");

            migrationBuilder.RenameColumn(
                name: "LayoutTextId",
                table: "WebsiteTextTranslations",
                newName: "WebsiteTextId");

            migrationBuilder.RenameIndex(
                name: "IX_WebsiteTextTranslations_LayoutTextId",
                table: "WebsiteTextTranslations",
                newName: "IX_WebsiteTextTranslations_WebsiteTextId");

            migrationBuilder.CreateTable(
                name: "PrivacyPolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacyPolicies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivacyPolicies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PrivacyPolicies_LanguageId",
                table: "PrivacyPolicies",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebsiteTextTranslations_WebsiteTexts_WebsiteTextId",
                table: "WebsiteTextTranslations",
                column: "WebsiteTextId",
                principalTable: "WebsiteTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WebsiteTextTranslations_WebsiteTexts_WebsiteTextId",
                table: "WebsiteTextTranslations");

            migrationBuilder.DropTable(
                name: "PrivacyPolicies");

            migrationBuilder.RenameColumn(
                name: "WebsiteTextId",
                table: "WebsiteTextTranslations",
                newName: "LayoutTextId");

            migrationBuilder.RenameIndex(
                name: "IX_WebsiteTextTranslations_WebsiteTextId",
                table: "WebsiteTextTranslations",
                newName: "IX_WebsiteTextTranslations_LayoutTextId");

            migrationBuilder.AddForeignKey(
                name: "FK_WebsiteTextTranslations_WebsiteTexts_LayoutTextId",
                table: "WebsiteTextTranslations",
                column: "LayoutTextId",
                principalTable: "WebsiteTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
