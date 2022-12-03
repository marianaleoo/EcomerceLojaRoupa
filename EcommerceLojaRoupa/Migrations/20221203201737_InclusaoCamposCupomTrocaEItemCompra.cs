using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class InclusaoCamposCupomTrocaEItemCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompraTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CupomTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "CupomTroca",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "valorTroca",
                table: "CupomTroca",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompra_CupomTrocaId",
                table: "ItemCompra",
                column: "CupomTrocaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra",
                column: "CupomTrocaId",
                principalTable: "CupomTroca",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropIndex(
                name: "IX_ItemCompra_CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "CompraTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "codigo",
                table: "CupomTroca");

            migrationBuilder.DropColumn(
                name: "valorTroca",
                table: "CupomTroca");
        }
    }
}
