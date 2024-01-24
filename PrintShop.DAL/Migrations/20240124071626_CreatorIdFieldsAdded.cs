using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatorIdFieldsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CreatorIds",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Presentation",
                table: "CreatorIds",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CreatorIds");

            migrationBuilder.DropColumn(
                name: "Presentation",
                table: "CreatorIds");
        }
    }
}
