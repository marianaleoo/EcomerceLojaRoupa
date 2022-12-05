using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoItemCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra");

            migrationBuilder.DropColumn(
                name: "CompraTrocaId",
                table: "ItemCompra");

            migrationBuilder.AlterColumn<int>(
                name: "CupomTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: true,
                defaultValue: null,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "CupomTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompraTrocaId",
                table: "ItemCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCompra_CupomTroca_CupomTrocaId",
                table: "ItemCompra",
                column: "CupomTrocaId",
                principalTable: "CupomTroca",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
