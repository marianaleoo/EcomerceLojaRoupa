using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class RetirarFKTabelaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId",
                principalTable: "CarrinhoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId",
                principalTable: "CarrinhoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
