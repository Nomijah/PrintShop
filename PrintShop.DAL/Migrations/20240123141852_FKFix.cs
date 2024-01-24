using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FKFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "UserCreatorIds",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CreatorIdentifier",
                table: "Pictures",
                newName: "CreatorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "IX_UserOrders_OrderId",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserCreatorIds",
                newName: "CreatorId");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Pictures",
                newName: "CreatorIdentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCreatorIds",
                table: "UserCreatorIds",
                columns: new[] { "CreatorId", "UserId" });
        }
    }
}
