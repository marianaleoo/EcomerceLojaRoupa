using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class ChaveClienteCartao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "CartaoCredito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartaoCredito_ClienteId",
                table: "CartaoCredito",
                column: "ClienteId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartaoCredito_Cliente_ClienteId",
                table: "CartaoCredito",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartaoCredito_Cliente_ClienteId",
                table: "CartaoCredito");

            migrationBuilder.DropIndex(
                name: "IX_CartaoCredito_ClienteId",
                table: "CartaoCredito");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "CartaoCredito");
        }
    }
}
