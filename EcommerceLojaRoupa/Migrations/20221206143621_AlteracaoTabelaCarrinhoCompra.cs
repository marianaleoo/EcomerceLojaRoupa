using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoTabelaCarrinhoCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId1",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CarrinhoId1",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "CarrinhoId1",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CarrinhoCompra");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente",
                column: "CarrinhoId");

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

            migrationBuilder.DropIndex(
                name: "IX_Cliente_CarrinhoId",
                table: "Cliente");

            migrationBuilder.AlterColumn<int>(
                name: "CarrinhoId",
                table: "Cliente",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId1",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CarrinhoCompra",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CarrinhoId1",
                table: "Cliente",
                column: "CarrinhoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_CarrinhoCompra_CarrinhoId1",
                table: "Cliente",
                column: "CarrinhoId1",
                principalTable: "CarrinhoCompra",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
