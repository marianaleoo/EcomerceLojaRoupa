using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoFKTabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_CupomPromocional_CupomPromocionalId",
                table: "Compra");

            migrationBuilder.DropIndex(
                name: "IX_Compra_CupomPromocionalId",
                table: "Compra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Compra_CupomPromocionalId",
                table: "Compra",
                column: "CupomPromocionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_CupomPromocional_CupomPromocionalId",
                table: "Compra",
                column: "CupomPromocionalId",
                principalTable: "CupomPromocional",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
