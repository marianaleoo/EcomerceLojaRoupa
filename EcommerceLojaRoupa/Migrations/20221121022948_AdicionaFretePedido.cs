using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AdicionaFretePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Frete",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frete",
                table: "Pedido");
        }
    }
}
