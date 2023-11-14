using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataSizeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e1d004c-7996-4354-9a18-253a094dd8c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7caa61e-5736-4ed4-b4e4-08593bf3049e");

            migrationBuilder.AlterColumn<int>(
                name: "Width",
                table: "PrintSize",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "PrintSize",
                type: "integer",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "822fa03f-b0be-4859-962d-15659b6ff1d0", "2", "Customer", "Customer" },
                    { "f09174bc-69a1-4507-ac4d-fad354d7028e", "1", "Admin", "Admin" }
                });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 30, "30x30", 30 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 50, "50x50", 50 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 70, "70x70", 70 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 100, "100x100", 100 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150, "150x150", 150 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 30, "30x45", 45 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 50, "50x75", 75 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 70, "70x105", 105 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 100, "100x150", 150 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150, "150x225", 225 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 45, "45x30", 30 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 75, "75x50", 50 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 105, "105x70", 70 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150, "150x100", 100 });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 225, "225x150", 150 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "822fa03f-b0be-4859-962d-15659b6ff1d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09174bc-69a1-4507-ac4d-fad354d7028e");

            migrationBuilder.AlterColumn<decimal>(
                name: "Width",
                table: "PrintSize",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "PrintSize",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e1d004c-7996-4354-9a18-253a094dd8c9", "1", "Admin", "Admin" },
                    { "b7caa61e-5736-4ed4-b4e4-08593bf3049e", "2", "Customer", "Customer" }
                });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 30m, "0x0", 30m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 102,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 50m, "0x0", 50m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 103,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 70m, "0x0", 70m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 104,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 100m, "0x0", 100m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 105,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150m, "0x0", 150m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 201,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 30m, "0x0", 45m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 202,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 50m, "0x0", 75m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 203,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 70m, "0x0", 105m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 204,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 100m, "0x0", 150m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 205,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150m, "0x0", 225m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 301,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 45m, "0x0", 30m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 302,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 75m, "0x0", 50m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 303,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 105m, "0x0", 70m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 304,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 150m, "0x0", 100m });

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 305,
                columns: new[] { "Height", "Size", "Width" },
                values: new object[] { 225m, "0x0", 150m });
        }
    }
}
