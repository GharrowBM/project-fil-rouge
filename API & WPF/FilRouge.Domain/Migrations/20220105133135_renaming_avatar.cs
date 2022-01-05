using Microsoft.EntityFrameworkCore.Migrations;

namespace FilRouge.Repositories.Migrations
{
    public partial class renaming_avatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarURI",
                table: "Users",
                newName: "AvatarPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AvatarPath",
                table: "Users",
                newName: "AvatarURI");
        }
    }
}
