using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SizeModelChangeAndSeedDataAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "PrintSize");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e1d004c-7996-4354-9a18-253a094dd8c9", "1", "Admin", "Admin" },
                    { "b7caa61e-5736-4ed4-b4e4-08593bf3049e", "2", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { 101, "Direktprint på Kapa är en prisvärd utskrift som lämpar sig för skyltproduktion eller tillfälliga utställningar.", true, "Kapa" },
                    { 102, "Direktprint på plywood är en högkvalitativ utskrift direkt på träytan.", true, "Plywood" },
                    { 103, "Tryck dina bilder på aluminium med lång hållbarhet och hög kvalitet. Trycket i kombination med aluminiumet ger dina bilder ett metalliskt skimmer och en modern industriell känsla.", true, "Aluminium" },
                    { 104, "Tryck dina bilder på reptåligt plexiglas i tjocklekarna 4 mm och 8 mm. Trycket är högkvalitativ och lämpligt för både inom- och utomhusbruk.", true, "Plexiglas" }
                });

            migrationBuilder.InsertData(
                table: "PrintSize",
                columns: new[] { "Id", "Height", "MaterialId", "Size", "Width" },
                values: new object[,]
                {
                    { 101, 30m, null, "0x0", 30m },
                    { 102, 50m, null, "0x0", 50m },
                    { 103, 70m, null, "0x0", 70m },
                    { 104, 100m, null, "0x0", 100m },
                    { 105, 150m, null, "0x0", 150m },
                    { 201, 30m, null, "0x0", 45m },
                    { 202, 50m, null, "0x0", 75m },
                    { 203, 70m, null, "0x0", 105m },
                    { 204, 100m, null, "0x0", 150m },
                    { 205, 150m, null, "0x0", 225m },
                    { 301, 45m, null, "0x0", 30m },
                    { 302, 75m, null, "0x0", 50m },
                    { 303, 105m, null, "0x0", 70m },
                    { 304, 150m, null, "0x0", 100m },
                    { 305, 225m, null, "0x0", 150m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e1d004c-7996-4354-9a18-253a094dd8c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7caa61e-5736-4ed4-b4e4-08593bf3049e");

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Materials",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.AddColumn<int>(
                name: "ArticleCode",
                table: "PrintSize",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
