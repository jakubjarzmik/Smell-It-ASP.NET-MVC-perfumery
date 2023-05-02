using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmellIt.Infrastructure.Migrations
{
    public partial class AddEncodedNameInLanguagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EncodedName",
                table: "Languages",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncodedName",
                table: "Languages");
        }
    }
}
