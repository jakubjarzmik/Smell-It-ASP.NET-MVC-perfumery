using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class UpdateSmellItDbContextTranslationsForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
