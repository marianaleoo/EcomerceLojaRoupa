using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CorrecaoCarrinhoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoCompra_Cliente_ClienteId",
                table: "CarrinhoCompra");

            migrationBuilder.DropIndex(
                name: "IX_CarrinhoCompra_ClienteId",
                table: "CarrinhoCompra");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CarrinhoCompra");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CarrinhoCompra",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoCompra_ClienteId",
                table: "CarrinhoCompra",
                column: "ClienteId",
                unique: true,
                filter: "[ClienteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoCompra_Cliente_ClienteId",
                table: "CarrinhoCompra",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
