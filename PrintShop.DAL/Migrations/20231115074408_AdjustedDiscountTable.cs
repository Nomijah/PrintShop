using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedDiscountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a90f578a-e79c-437f-a2ae-6bec993da1a9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f81f345c-ff05-48fc-aed6-a86cc1bae98d");

            migrationBuilder.DropColumn(
                name: "PercentOff",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "PriceOff",
                table: "Discounts",
                newName: "AmountOff");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Materials",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "DiscountType",
                table: "Discounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumItems",
                table: "Discounts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumSpent",
                table: "Discounts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3045b38f-a379-464d-b9f6-5d1ced856bf5", "2", "Customer", "Customer" },
                    { "ceea22f0-cf86-47cd-bb16-f04ada328c4b", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3045b38f-a379-464d-b9f6-5d1ced856bf5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ceea22f0-cf86-47cd-bb16-f04ada328c4b");

            migrationBuilder.DropColumn(
                name: "DiscountType",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "MinimumItems",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "MinimumSpent",
                table: "Discounts");

            migrationBuilder.RenameColumn(
                name: "AmountOff",
                table: "Discounts",
                newName: "PriceOff");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Materials",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Materials",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PercentOff",
                table: "Discounts",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a90f578a-e79c-437f-a2ae-6bec993da1a9", "2", "Customer", "Customer" },
                    { "f81f345c-ff05-48fc-aed6-a86cc1bae98d", "1", "Admin", "Admin" }
                });
        }
    }
}
