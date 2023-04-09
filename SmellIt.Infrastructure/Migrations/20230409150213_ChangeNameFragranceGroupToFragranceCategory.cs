using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class ChangeNameFragranceGroupToFragranceCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FragranceGroups_Users_CreatedById",
                table: "FragranceGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceGroups_Users_DeletedById",
                table: "FragranceGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_FragranceGroups_Users_ModifiedById",
                table: "FragranceGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_FragranceGroups_FragranceGroupId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FragranceGroups",
                table: "FragranceGroups");

            migrationBuilder.RenameTable(
                name: "FragranceGroups",
                newName: "FragranceCategories");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceGroups_ModifiedById",
                table: "FragranceCategories",
                newName: "IX_FragranceCategories_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceGroups_DeletedById",
                table: "FragranceCategories",
                newName: "IX_FragranceCategories_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceGroups_CreatedById",
                table: "FragranceCategories",
                newName: "IX_FragranceCategories_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceCategories",
                table: "FragranceCategories",
                column: "Id");

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
                name: "FK_Products_FragranceCategories_FragranceGroupId",
                table: "Products",
                column: "FragranceGroupId",
                principalTable: "FragranceCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_Products_FragranceCategories_FragranceGroupId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FragranceCategories",
                table: "FragranceCategories");

            migrationBuilder.RenameTable(
                name: "FragranceCategories",
                newName: "FragranceGroups");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceCategories_ModifiedById",
                table: "FragranceGroups",
                newName: "IX_FragranceGroups_ModifiedById");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceCategories_DeletedById",
                table: "FragranceGroups",
                newName: "IX_FragranceGroups_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_FragranceCategories_CreatedById",
                table: "FragranceGroups",
                newName: "IX_FragranceGroups_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FragranceGroups",
                table: "FragranceGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceGroups_Users_CreatedById",
                table: "FragranceGroups",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceGroups_Users_DeletedById",
                table: "FragranceGroups",
                column: "DeletedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FragranceGroups_Users_ModifiedById",
                table: "FragranceGroups",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_FragranceGroups_FragranceGroupId",
                table: "Products",
                column: "FragranceGroupId",
                principalTable: "FragranceGroups",
                principalColumn: "Id");
        }
    }
}
