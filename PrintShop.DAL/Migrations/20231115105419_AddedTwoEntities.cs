using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedTwoEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ca9260b-d6c0-4b76-8e45-6ea11fd69ff4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86d78f5c-d470-430a-824f-4a2d8687a8d9");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Pictures");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "UserOrder",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrder", x => new { x.UserId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_UserOrder_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PictureTag",
                columns: table => new
                {
                    PicturesId = table.Column<int>(type: "integer", nullable: false),
                    TagsName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureTag", x => new { x.PicturesId, x.TagsName });
                    table.ForeignKey(
                        name: "FK_PictureTag_Pictures_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureTag_Tag_TagsName",
                        column: x => x.TagsName,
                        principalTable: "Tag",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e78ecd1-10f8-4eae-8faf-44d1bcc61133", "2", "Customer", "Customer" },
                    { "ebcf7a7d-e0c1-46bc-85e4-20d893b2e16a", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureTag_TagsName",
                table: "PictureTag",
                column: "TagsName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureTag");

            migrationBuilder.DropTable(
                name: "UserOrder");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e78ecd1-10f8-4eae-8faf-44d1bcc61133");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebcf7a7d-e0c1-46bc-85e4-20d893b2e16a");

            migrationBuilder.AddColumn<List<string>>(
                name: "Tags",
                table: "Pictures",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ca9260b-d6c0-4b76-8e45-6ea11fd69ff4", "2", "Customer", "Customer" },
                    { "86d78f5c-d470-430a-824f-4a2d8687a8d9", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserId",
                table: "Orders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
