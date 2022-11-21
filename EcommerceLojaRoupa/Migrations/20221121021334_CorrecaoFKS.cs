using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CorrecaoFKS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCarrinhoId",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido",
                column: "ItemCarrinhoId",
                principalTable: "ItemCarrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ItemCarrinhoId",
                table: "Pedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                table: "Pedido",
                column: "ItemCarrinhoId",
                principalTable: "ItemCarrinho",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
