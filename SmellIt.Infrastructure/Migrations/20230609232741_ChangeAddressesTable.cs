using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAddressesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Addresses",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "FirstLine",
                table: "Addresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondLine",
                table: "Addresses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstLine",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "SecondLine",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Addresses",
                newName: "Street");
        }
    }
}
