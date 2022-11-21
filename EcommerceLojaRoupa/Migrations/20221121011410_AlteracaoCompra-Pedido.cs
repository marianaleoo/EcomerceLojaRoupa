using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoCompraPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Frete = table.Column<double>(type: "float", nullable: true),
                    ValorTotalVenda = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Frete = table.Column<double>(type: "float", nullable: false),
                    ValorVenda = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.Id);
                });
        }
    }
}
