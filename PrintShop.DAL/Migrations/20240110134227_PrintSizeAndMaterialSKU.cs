using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class PrintSizeAndMaterialSKU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiscountProducts");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropColumn(
                name: "SKUPart",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "SKU",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SKUPart",
                table: "Pictures");

            migrationBuilder.RenameColumn(
                name: "url",
                table: "Pictures",
                newName: "Url");

            migrationBuilder.AddColumn<string>(
                name: "SKUPart",
                table: "PrintSizes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PictureTags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    PictureId = table.Column<int>(type: "integer", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false)
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
                        name: "FK_PictureTags_Tags_TagName",
                        column: x => x.TagName,
                        principalTable: "Tags",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 101,
                column: "SKUPart",
                value: "030030");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 102,
                column: "SKUPart",
                value: "050050");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 103,
                column: "SKUPart",
                value: "070070");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 104,
                column: "SKUPart",
                value: "100100");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 105,
                column: "SKUPart",
                value: "150150");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 201,
                column: "SKUPart",
                value: "030045");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 202,
                column: "SKUPart",
                value: "050075");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 203,
                column: "SKUPart",
                value: "070105");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 204,
                column: "SKUPart",
                value: "100150");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 205,
                column: "SKUPart",
                value: "150225");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 301,
                column: "SKUPart",
                value: "045030");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 302,
                column: "SKUPart",
                value: "075050");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 303,
                column: "SKUPart",
                value: "105070");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 304,
                column: "SKUPart",
                value: "150100");

            migrationBuilder.UpdateData(
                table: "PrintSizes",
                keyColumn: "Id",
                keyValue: 305,
                column: "SKUPart",
                value: "225150");

            migrationBuilder.CreateIndex(
                name: "IX_PictureTags_TagName",
                table: "PictureTags",
                column: "TagName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PictureTags");

            migrationBuilder.DropColumn(
                name: "SKUPart",
                table: "PrintSizes");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Pictures",
                newName: "url");

            migrationBuilder.AddColumn<string>(
                name: "SKUPart",
                table: "Variants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKUPart",
                table: "Pictures",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AmountOff = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinimumItems = table.Column<decimal>(type: "numeric", nullable: false),
                    MinimumSpent = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    isActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiscountProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountId = table.Column<int>(type: "integer", nullable: false),
                    PictureId = table.Column<int>(type: "integer", nullable: true),
                    ProductId = table.Column<int>(type: "integer", nullable: true),
                    VariantId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "Pictures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DiscountProducts_Variants_VariantId",
                        column: x => x.VariantId,
                        principalTable: "Variants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_DiscountId",
                table: "DiscountProducts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_PictureId",
                table: "DiscountProducts",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_ProductId",
                table: "DiscountProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountProducts_VariantId",
                table: "DiscountProducts",
                column: "VariantId");
        }
    }
}
