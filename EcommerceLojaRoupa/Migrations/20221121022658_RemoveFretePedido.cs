using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class RemoveFretePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Frete",
                table: "Pedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Frete",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
