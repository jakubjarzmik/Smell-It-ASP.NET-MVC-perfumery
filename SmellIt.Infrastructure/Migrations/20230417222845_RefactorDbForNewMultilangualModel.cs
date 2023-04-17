using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class RefactorDbForNewMultilangualModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FragranceCategories_FragranceGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "TranslationEngbs");

            migrationBuilder.DropTable(
                name: "TranslationPlpls");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "NameKey",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "FragranceGroupId",
                table: "Products",
                newName: "FragranceCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FragranceGroupId",
                table: "Products",
                newName: "IX_Products_FragranceCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageAlt",
                table: "ProductImages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "FragranceCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Languages_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Languages_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Languages_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BrandTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BrandTranslations_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FragranceCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FragranceCategoryId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FragranceCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FragranceCategoryTranslations_FragranceCategories_FragranceCategoryId",
                        column: x => x.FragranceCategoryId,
                        principalTable: "FragranceCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FragranceCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FragranceCategoryTranslations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FragranceCategoryTranslations_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FragranceCategoryTranslations_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenderTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenderTranslations_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenderTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenderTranslations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenderTranslations_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GenderTranslations_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductCategoryTranslations_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    EncodedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductTranslations_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_BrandId",
                table: "BrandTranslations",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_CreatedById",
                table: "BrandTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_DeletedById",
                table: "BrandTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_LanguageId",
                table: "BrandTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandTranslations_ModifiedById",
                table: "BrandTranslations",
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
                name: "IX_FragranceCategoryTranslations_FragranceCategoryId",
                table: "FragranceCategoryTranslations",
                column: "FragranceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategoryTranslations_LanguageId",
                table: "FragranceCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_FragranceCategoryTranslations_ModifiedById",
                table: "FragranceCategoryTranslations",
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
                name: "IX_GenderTranslations_GenderId",
                table: "GenderTranslations",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTranslations_LanguageId",
                table: "GenderTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_GenderTranslations_ModifiedById",
                table: "GenderTranslations",
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
                name: "IX_ProductCategoryTranslations_CreatedById",
                table: "ProductCategoryTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_DeletedById",
                table: "ProductCategoryTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_LanguageId",
                table: "ProductCategoryTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_ModifiedById",
                table: "ProductCategoryTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategoryTranslations_ProductCategoryId",
                table: "ProductCategoryTranslations",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_CreatedById",
                table: "ProductTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_DeletedById",
                table: "ProductTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_LanguageId",
                table: "ProductTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ModifiedById",
                table: "ProductTranslations",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTranslations_ProductId",
                table: "ProductTranslations",
                column: "ProductId");

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
                name: "FK_Products_FragranceCategories_FragranceCategoryId",
                table: "Products",
                column: "FragranceCategoryId",
                principalTable: "FragranceCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FragranceCategories_FragranceCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_CategoryId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BrandTranslations");

            migrationBuilder.DropTable(
                name: "FragranceCategoryTranslations");

            migrationBuilder.DropTable(
                name: "GenderTranslations");

            migrationBuilder.DropTable(
                name: "ProductCategoryTranslations");

            migrationBuilder.DropTable(
                name: "ProductTranslations");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Login",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "FragranceCategories");

            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "FragranceCategoryId",
                table: "Products",
                newName: "FragranceGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_FragranceCategoryId",
                table: "Products",
                newName: "IX_Products_FragranceGroupId");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ImageAlt",
                table: "ProductImages",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "ProductCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "ProductCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Genders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "Genders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "FragranceCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "FragranceCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Brands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameKey",
                table: "Brands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TranslationEngbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationEngbs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationEngbs_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranslationEngbs_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranslationEngbs_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TranslationPlpls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<int>(type: "int", nullable: true),
                    ModifiedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationPlpls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationPlpls_Users_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranslationPlpls_Users_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TranslationPlpls_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslationEngbs_CreatedById",
                table: "TranslationEngbs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationEngbs_DeletedById",
                table: "TranslationEngbs",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationEngbs_Key",
                table: "TranslationEngbs",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslationEngbs_ModifiedById",
                table: "TranslationEngbs",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationPlpls_CreatedById",
                table: "TranslationPlpls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationPlpls_DeletedById",
                table: "TranslationPlpls",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationPlpls_Key",
                table: "TranslationPlpls",
                column: "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslationPlpls_ModifiedById",
                table: "TranslationPlpls",
                column: "ModifiedById");

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
                name: "FK_Products_FragranceCategories_FragranceGroupId",
                table: "Products",
                column: "FragranceGroupId",
                principalTable: "FragranceCategories",
                principalColumn: "Id");

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
