using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CreatorIdFKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorIdId",
                table: "Pictures",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_CreatorIdId",
                table: "Pictures",
                column: "CreatorIdId");

            migrationBuilder.CreateIndex(
                name: "IX_CreatorIds_UserId",
                table: "CreatorIds",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreatorIds_Users_UserId",
                table: "CreatorIds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_CreatorIds_CreatorIdId",
                table: "Pictures",
                column: "CreatorIdId",
                principalTable: "CreatorIds",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreatorIds_Users_UserId",
                table: "CreatorIds");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_CreatorIds_CreatorIdId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_CreatorIdId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_CreatorIds_UserId",
                table: "CreatorIds");

            migrationBuilder.DropColumn(
                name: "CreatorIdId",
                table: "Pictures");
        }
    }
}
