using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CorrecaotabelaPedidoECriacaoTabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemCarrinhoId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItemCarrinhoId",
                table: "Pedido",
                column: "ItemCarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido",
                column: "ItemCarrinhoId",
                principalTable: "ItemCarrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ItemCarrinhoId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ItemCarrinhoId",
                table: "Pedido");
        }
    }
}
