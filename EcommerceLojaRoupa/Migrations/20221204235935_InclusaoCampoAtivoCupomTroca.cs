using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class InclusaoCampoAtivoCupomTroca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.AlterColumn<int>(
                name: "CupomTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "ativo",
                table: "CupomTroca",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra",
                column: "CupomTrocaId",
                principalTable: "CupomTroca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "ativo",
                table: "CupomTroca");

            migrationBuilder.AlterColumn<int>(
                name: "CupomTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra",
                column: "CupomTrocaId",
                principalTable: "CupomTroca",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
