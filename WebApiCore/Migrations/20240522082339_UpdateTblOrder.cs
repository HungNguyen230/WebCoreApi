using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiCore.Migrations
{
    public partial class UpdateTblOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_ProductsId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_ProductsId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductsId",
                table: "Order",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_ProductsId",
                table: "Order",
                column: "ProductsId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
