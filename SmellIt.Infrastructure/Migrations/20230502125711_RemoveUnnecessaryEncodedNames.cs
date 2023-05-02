using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class RemoveUnnecessaryEncodedNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "WebsiteTextTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "HomeBannerTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "GenderTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "BrandTranslations");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductCategoryId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "WebsiteTextTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "ProductTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "ProductImages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "ProductCategoryTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Languages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "HomeBannerTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "GenderTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Genders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "FragranceCategoryTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "BrandTranslations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Addresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
