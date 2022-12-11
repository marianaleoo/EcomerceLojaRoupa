using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AlteracaoTabelaRoupa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Roupa",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Roupa_CategoriaId",
                table: "Roupa",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roupa_Categoria_CategoriaId",
                table: "Roupa",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roupa_Categoria_CategoriaId",
                table: "Roupa");

            migrationBuilder.DropIndex(
                name: "IX_Roupa_CategoriaId",
                table: "Roupa");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Roupa");
        }
    }
}
