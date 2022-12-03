using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class CriacaoECorrecaoTabelaCompraItemCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "ItemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoupaId",
                table: "ItemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "preco",
                table: "ItemCompra",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_CompraId",
                table: "ItemCompra",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_RoupaId",
                table: "ItemCompra",
                column: "RoupaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_Compra_CompraId",
                table: "ItemCompra",
                column: "CompraId",
                principalTable: "Compra",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_Roupa_RoupaId",
                table: "ItemCompra",
                column: "RoupaId",
                principalTable: "Roupa",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_Compra_CompraId",
                table: "ItemCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_Roupa_RoupaId",
                table: "ItemCompra");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompra_CompraId",
                table: "ItemCompra");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompra_RoupaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "RoupaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "preco",
                table: "ItemCompra");
        }
    }
}
