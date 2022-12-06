using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CorrecaoTabelaCarrinho : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clienteCarrinho",
                table: "CarrinhoCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clienteCarrinho",
                table: "CarrinhoCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
