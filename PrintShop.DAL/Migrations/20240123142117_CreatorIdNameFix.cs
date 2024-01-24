using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatorIdNameFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds");

            migrationBuilder.RenameTable(
                name: "UserCreatorIds",
                newName: "CreatorIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreatorIds",
                table: "CreatorIds",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CreatorIds",
                table: "CreatorIds");

            migrationBuilder.RenameTable(
                name: "CreatorIds",
                newName: "UserCreatorIds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds",
                column: "Id");
        }
    }
}
