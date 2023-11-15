using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedDiscountProblemInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Pictures_PictureId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Variants_VariantId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_PictureId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_VariantId",
                table: "Discounts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3045b38f-a379-464d-b9f6-5d1ced856bf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceea22f0-cf86-47cd-bb16-f04ada328c4b");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "Discounts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ca9260b-d6c0-4b76-8e45-6ea11fd69ff4", "2", "Customer", "Customer" },
                    { "86d78f5c-d470-430a-824f-4a2d8687a8d9", "1", "Admin", "Admin" }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountProducts_Pictures_PictureId",
                table: "DiscountProducts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountProducts_Products_ProductId",
                table: "DiscountProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiscountProducts_Variants_VariantId",
                table: "DiscountProducts",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiscountProducts_Pictures_PictureId",
                table: "DiscountProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountProducts_Products_ProductId",
                table: "DiscountProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_DiscountProducts_Variants_VariantId",
                table: "DiscountProducts");

            migrationBuilder.DropIndex(
                name: "IX_DiscountProducts_PictureId",
                table: "DiscountProducts");

            migrationBuilder.DropIndex(
                name: "IX_DiscountProducts_ProductId",
                table: "DiscountProducts");

            migrationBuilder.DropIndex(
                name: "IX_DiscountProducts_VariantId",
                table: "DiscountProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ca9260b-d6c0-4b76-8e45-6ea11fd69ff4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86d78f5c-d470-430a-824f-4a2d8687a8d9");

            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Discounts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Discounts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "Discounts",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3045b38f-a379-464d-b9f6-5d1ced856bf5", "2", "Customer", "Customer" },
                    { "ceea22f0-cf86-47cd-bb16-f04ada328c4b", "1", "Admin", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PictureId",
                table: "Discounts",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_VariantId",
                table: "Discounts",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Pictures_PictureId",
                table: "Discounts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_ProductId",
                table: "Discounts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Variants_VariantId",
                table: "Discounts",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id");
        }
    }
}
