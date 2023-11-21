using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserCreatorIdsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87ce2125-4c09-45b3-a31e-8d494513c9a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91ccad20-33ab-45e9-bf5d-6ab78ce63c70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d15a6051-f373-495e-a3df-96b949d5f92f");

            migrationBuilder.CreateTable(
                name: "UserCreatorIds",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCreatorIds", x => new { x.CreatorId, x.UserId });
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d94fd8e-a64b-4104-9aae-e2b8799dd349", "1", "Admin", "ADMIN" },
                    { "bd4f79d2-4725-4c95-85a1-74ebf555c93a", "2", "Customer", "CUSTOMER" },
                    { "f9c3bf7a-b6a4-4537-a0cc-217e34ffe026", "3", "Creator", "CREATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCreatorIds");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d94fd8e-a64b-4104-9aae-e2b8799dd349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd4f79d2-4725-4c95-85a1-74ebf555c93a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9c3bf7a-b6a4-4537-a0cc-217e34ffe026");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "87ce2125-4c09-45b3-a31e-8d494513c9a1", "2", "Customer", "CUSTOMER" },
                    { "91ccad20-33ab-45e9-bf5d-6ab78ce63c70", "3", "Creator", "CREATOR" },
                    { "d15a6051-f373-495e-a3df-96b949d5f92f", "1", "Admin", "ADMIN" }
                });
        }
    }
}
