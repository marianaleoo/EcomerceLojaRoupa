using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class ExclusaoTabelaPedidoECorrecaoTabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Pedido_PedidoId",
                table: "Compra");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Compra_PedidoId",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "CupomPromocionalId",
                table: "Compra",
                newName: "CupomTrocaId");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compra_ClienteId",
                table: "Compra",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_ClienteId",
                table: "Compra");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Compra");

            migrationBuilder.RenameColumn(
                name: "CupomTrocaId",
                table: "Compra",
                newName: "CupomPromocionalId");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frete = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCarrinhoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValorTotalVenda = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedido_ItemCarrinho_ItemCarrinhoId",
                        column: x => x.ItemCarrinhoId,
                        principalTable: "ItemCarrinho",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_PedidoId",
                table: "Compra",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ItemCarrinhoId",
                table: "Pedido",
                column: "ItemCarrinhoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Pedido_PedidoId",
                table: "Compra",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
