using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class ChangeForTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FragranceGroups");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "NameKey");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductCategories",
                newName: "NameKey");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genders",
                newName: "NameKey");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FragranceGroups",
                newName: "NameKey");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Brands",
                newName: "NameKey");

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "ProductCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Genders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "FragranceGroups",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionKey",
                table: "Brands",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Genders");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "FragranceGroups");

            migrationBuilder.DropColumn(
                name: "DescriptionKey",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "NameKey",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameKey",
                table: "ProductCategories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameKey",
                table: "Genders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameKey",
                table: "FragranceGroups",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameKey",
                table: "Brands",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FragranceGroups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
