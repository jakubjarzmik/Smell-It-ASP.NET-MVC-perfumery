using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class SomeBugFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Brands_BrandId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_FragranceCategories_FragranceCategoryId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Genders_GenderId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Brands_BrandId",
                table: "BrandTranslations",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_FragranceCategories_FragranceCategoryId",
                table: "FragranceCategoryTranslations",
                column: "FragranceCategoryId",
                principalTable: "FragranceCategories",
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
                name: "FK_GenderTranslations_Genders_GenderId",
                table: "GenderTranslations",
                column: "GenderId",
                principalTable: "Genders",
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
                name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                table: "ProductCategoryTranslations",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Brands_BrandId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_FragranceCategories_FragranceCategoryId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Genders_GenderId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Languages_LanguageId",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Brands_BrandId",
                table: "BrandTranslations",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Languages_LanguageId",
                table: "BrandTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_FragranceCategories_FragranceCategoryId",
                table: "FragranceCategoryTranslations",
                column: "FragranceCategoryId",
                principalTable: "FragranceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                table: "FragranceCategoryTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Genders_GenderId",
                table: "GenderTranslations",
                column: "GenderId",
                principalTable: "Genders",
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
                name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                table: "ProductCategoryTranslations",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Languages_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Products_ProductId",
                table: "ProductTranslations",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
