using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CorrecaoChavesCartaoCreditoEItemCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemCarrinho_RoupaId",
                table: "ItemCarrinho");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCredito_BandeiraId",
                table: "CartaoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_RoupaId",
                table: "ItemCarrinho",
                column: "RoupaId");

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_BandeiraId",
                table: "CartaoCredito",
                column: "BandeiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemCarrinho_RoupaId",
                table: "ItemCarrinho");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCredito_BandeiraId",
                table: "CartaoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinho_RoupaId",
                table: "ItemCarrinho",
                column: "RoupaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_BandeiraId",
                table: "CartaoCredito",
                column: "BandeiraId",
                unique: true);
        }
    }
}
