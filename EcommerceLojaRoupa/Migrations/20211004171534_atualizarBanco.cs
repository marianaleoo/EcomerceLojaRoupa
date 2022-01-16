using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class atualizarBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Roupa_RoupaId",
                table: "ItemCarrinho");

            migrationBuilder.AlterColumn<int>(
                name: "RoupaId",
                table: "ItemCarrinho",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Roupa_RoupaId",
                table: "ItemCarrinho",
                column: "RoupaId",
                principalTable: "Roupa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrinho_Roupa_RoupaId",
                table: "ItemCarrinho");

            migrationBuilder.AlterColumn<int>(
                name: "RoupaId",
                table: "ItemCarrinho",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrinho_Roupa_RoupaId",
                table: "ItemCarrinho",
                column: "RoupaId",
                principalTable: "Roupa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
