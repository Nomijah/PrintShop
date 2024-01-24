using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MultiplePictureTagDBFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureTags");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PictureTags",
                columns: table => new
                {
                    PictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    TagTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureTags", x => new { x.PictureId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PictureTags_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureTags_Tags_TagTitle",
                        column: x => x.TagTitle,
                        principalTable: "Tags",
                        principalColumn: "Title",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PictureTags_TagTitle",
                table: "PictureTags",
                column: "TagTitle");
        }
    }
}
