using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class DeleteUsersForIdentityAndAddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_CreatedById",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_DeletedById",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_ModifiedById",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_CreatedById",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_DeletedById",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_ModifiedById",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Users_CreatedById",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Users_DeletedById",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_BrandTranslations_Users_ModifiedById",
                table: "BrandTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategories_Users_CreatedById",
                table: "FragranceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategories_Users_DeletedById",
                table: "FragranceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategories_Users_ModifiedById",
                table: "FragranceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_CreatedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_DeletedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_ModifiedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Users_CreatedById",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Users_DeletedById",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Users_ModifiedById",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Users_CreatedById",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Users_DeletedById",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_GenderTranslations_Users_ModifiedById",
                table: "GenderTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Users_CreatedById",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Users_DeletedById",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Users_ModifiedById",
                table: "Languages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Users_CreatedById",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Users_DeletedById",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Users_ModifiedById",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Users_CreatedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Users_DeletedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryTranslations_Users_ModifiedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_CreatedById",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_DeletedById",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_ModifiedById",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeletedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_ModifiedById",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Users_CreatedById",
                table: "ProductTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Users_DeletedById",
                table: "ProductTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTranslations_Users_ModifiedById",
                table: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_CreatedById",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_DeletedById",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductTranslations_ModifiedById",
                table: "ProductTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeletedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ModifiedById",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_CreatedById",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_DeletedById",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ModifiedById",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategoryTranslations_CreatedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategoryTranslations_DeletedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategoryTranslations_ModifiedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_CreatedById",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_DeletedById",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ModifiedById",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_Languages_CreatedById",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_DeletedById",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ModifiedById",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_GenderTranslations_CreatedById",
                table: "GenderTranslations");

            migrationBuilder.DropIndex(
                name: "IX_GenderTranslations_DeletedById",
                table: "GenderTranslations");

            migrationBuilder.DropIndex(
                name: "IX_GenderTranslations_ModifiedById",
                table: "GenderTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Genders_CreatedById",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_DeletedById",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_Genders_ModifiedById",
                table: "Genders");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategoryTranslations_CreatedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategoryTranslations_DeletedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategoryTranslations_ModifiedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategories_CreatedById",
                table: "FragranceCategories");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategories_DeletedById",
                table: "FragranceCategories");

            migrationBuilder.DropIndex(
                name: "IX_FragranceCategories_ModifiedById",
                table: "FragranceCategories");

            migrationBuilder.DropIndex(
                name: "IX_BrandTranslations_CreatedById",
                table: "BrandTranslations");

            migrationBuilder.DropIndex(
                name: "IX_BrandTranslations_DeletedById",
                table: "BrandTranslations");

            migrationBuilder.DropIndex(
                name: "IX_BrandTranslations_ModifiedById",
                table: "BrandTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CreatedById",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_DeletedById",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_ModifiedById",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CreatedById",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_DeletedById",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ModifiedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ProductTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ProductCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "GenderTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "GenderTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "GenderTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "FragranceCategoryTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "BrandTranslations");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "BrandTranslations");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "BrandTranslations");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ProductTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "ProductTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "ProductTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "ProductImages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ProductCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "ProductCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "ProductCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "ProductCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "ProductCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "ProductCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Languages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "GenderTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "GenderTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "GenderTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Genders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Genders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Genders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "FragranceCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "FragranceCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "FragranceCategoryTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "FragranceCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "FragranceCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "FragranceCategories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "BrandTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "BrandTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "BrandTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Brands",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedById",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_CreatedById",
                table: "ProductTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_DeletedById",
                table: "ProductTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ModifiedById",
                table: "ProductTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedById",
                table: "Products",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedById",
                table: "Products",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedById",
                table: "Products",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedById",
                table: "ProductImages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_DeletedById",
                table: "ProductImages",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ModifiedById",
                table: "ProductImages",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_CreatedById",
                table: "ProductCategoryTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_DeletedById",
                table: "ProductCategoryTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_ModifiedById",
                table: "ProductCategoryTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CreatedById",
                table: "ProductCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_DeletedById",
                table: "ProductCategories",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ModifiedById",
                table: "ProductCategories",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatedById",
                table: "Languages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_DeletedById",
                table: "Languages",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ModifiedById",
                table: "Languages",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTranslations_CreatedById",
                table: "GenderTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTranslations_DeletedById",
                table: "GenderTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTranslations_ModifiedById",
                table: "GenderTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_CreatedById",
                table: "Genders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_DeletedById",
                table: "Genders",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Genders_ModifiedById",
                table: "Genders",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategoryTranslations_CreatedById",
                table: "FragranceCategoryTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategoryTranslations_DeletedById",
                table: "FragranceCategoryTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategoryTranslations_ModifiedById",
                table: "FragranceCategoryTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategories_CreatedById",
                table: "FragranceCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategories_DeletedById",
                table: "FragranceCategories",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategories_ModifiedById",
                table: "FragranceCategories",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_CreatedById",
                table: "BrandTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_DeletedById",
                table: "BrandTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_ModifiedById",
                table: "BrandTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CreatedById",
                table: "Brands",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_DeletedById",
                table: "Brands",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ModifiedById",
                table: "Brands",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CreatedById",
                table: "Addresses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_DeletedById",
                table: "Addresses",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ModifiedById",
                table: "Addresses",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedById",
                table: "Users",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedById",
                table: "Users",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedById",
                table: "Users",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_CreatedById",
                table: "Addresses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_DeletedById",
                table: "Addresses",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Users_ModifiedById",
                table: "Addresses",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_CreatedById",
                table: "Brands",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_DeletedById",
                table: "Brands",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_ModifiedById",
                table: "Brands",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Users_CreatedById",
                table: "BrandTranslations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Users_DeletedById",
                table: "BrandTranslations",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BrandTranslations_Users_ModifiedById",
                table: "BrandTranslations",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategories_Users_CreatedById",
                table: "FragranceCategories",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategories_Users_DeletedById",
                table: "FragranceCategories",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategories_Users_ModifiedById",
                table: "FragranceCategories",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_CreatedById",
                table: "FragranceCategoryTranslations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_DeletedById",
                table: "FragranceCategoryTranslations",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceCategoryTranslations_Users_ModifiedById",
                table: "FragranceCategoryTranslations",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Users_CreatedById",
                table: "Genders",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Users_DeletedById",
                table: "Genders",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Users_ModifiedById",
                table: "Genders",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Users_CreatedById",
                table: "GenderTranslations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Users_DeletedById",
                table: "GenderTranslations",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenderTranslations_Users_ModifiedById",
                table: "GenderTranslations",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Users_CreatedById",
                table: "Languages",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Users_DeletedById",
                table: "Languages",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Users_ModifiedById",
                table: "Languages",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Users_CreatedById",
                table: "ProductCategories",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Users_DeletedById",
                table: "ProductCategories",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Users_ModifiedById",
                table: "ProductCategories",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryTranslations_Users_CreatedById",
                table: "ProductCategoryTranslations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryTranslations_Users_DeletedById",
                table: "ProductCategoryTranslations",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryTranslations_Users_ModifiedById",
                table: "ProductCategoryTranslations",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_CreatedById",
                table: "ProductImages",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_DeletedById",
                table: "ProductImages",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_ModifiedById",
                table: "ProductImages",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedById",
                table: "Products",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedById",
                table: "Products",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_ModifiedById",
                table: "Products",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Users_CreatedById",
                table: "ProductTranslations",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Users_DeletedById",
                table: "ProductTranslations",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTranslations_Users_ModifiedById",
                table: "ProductTranslations",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
