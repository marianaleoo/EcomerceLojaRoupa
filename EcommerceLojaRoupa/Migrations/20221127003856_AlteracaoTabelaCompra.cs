using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoTabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoEntregaId = table.Column<int>(type: "int", nullable: false),
                    CupomPromocionalId = table.Column<int>(type: "int", nullable: false),
                    CartaoCreditoId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Compra_CartaoCredito_CartaoCreditoId",
                        column: x => x.CartaoCreditoId,
                        principalTable: "CartaoCredito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Compra_CupomPromocional_CupomPromocionalId",
                        column: x => x.CupomPromocionalId,
                        principalTable: "CupomPromocional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Compra_EnderecoEntrega_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "EnderecoEntrega",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Compra_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CartaoCreditoId",
                table: "Compra",
                column: "CartaoCreditoId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_CupomPromocionalId",
                table: "Compra",
                column: "CupomPromocionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_EnderecoEntregaId",
                table: "Compra",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Compra_PedidoId",
                table: "Compra",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");
        }
    }
}
