using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class ExclusaoCampoCupomIdTabelaCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CupomTrocaId",
                table: "Compra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CupomTrocaId",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
