using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSizeFromMaterialRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrintSize_Materials_MaterialId",
                table: "PrintSize");

            migrationBuilder.DropIndex(
                name: "IX_PrintSize_MaterialId",
                table: "PrintSize");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "822fa03f-b0be-4859-962d-15659b6ff1d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f09174bc-69a1-4507-ac4d-fad354d7028e");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "PrintSize");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a90f578a-e79c-437f-a2ae-6bec993da1a9", "2", "Customer", "Customer" },
                    { "f81f345c-ff05-48fc-aed6-a86cc1bae98d", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90f578a-e79c-437f-a2ae-6bec993da1a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81f345c-ff05-48fc-aed6-a86cc1bae98d");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "PrintSize",
                type: "integer",
                nullable: true);

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
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 102,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 103,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 104,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 105,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 201,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 202,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 203,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 204,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 205,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 301,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 302,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 303,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 304,
                column: "MaterialId",
                value: null);

            migrationBuilder.UpdateData(
                table: "PrintSize",
                keyColumn: "Id",
                keyValue: 305,
                column: "MaterialId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_PrintSize_MaterialId",
                table: "PrintSize",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintSize_Materials_MaterialId",
                table: "PrintSize",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");
        }
    }
}
