using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoTabelaItemCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "preco",
                table: "ItemCompra",
                newName: "Preco");

            migrationBuilder.AddColumn<bool>(
                name: "AceitarTroca",
                table: "ItemCompra",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RecusarTroca",
                table: "ItemCompra",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AceitarTroca",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "RecusarTroca",
                table: "ItemCompra");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "ItemCompra",
                newName: "preco");
        }
    }
}
