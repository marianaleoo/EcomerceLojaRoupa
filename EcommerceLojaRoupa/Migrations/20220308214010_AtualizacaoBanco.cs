using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class AtualizacaoBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais_PaisId",
                table: "Estado");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Estado",
                newName: "paisId");

            migrationBuilder.RenameIndex(
                name: "IX_Estado_PaisId",
                table: "Estado",
                newName: "IX_Estado_paisId");

            migrationBuilder.RenameColumn(
                name: "CidadeId",
                table: "Endereco",
                newName: "cidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_CidadeId",
                table: "Endereco",
                newName: "IX_Endereco_cidadeId");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Cidade",
                newName: "estadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidade_EstadoId",
                table: "Cidade",
                newName: "IX_Cidade_estadoId");

            migrationBuilder.AlterColumn<int>(
                name: "paisId",
                table: "Estado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "cidadeId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estadoId",
                table: "Cidade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_estadoId",
                table: "Cidade",
                column: "estadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_cidadeId",
                table: "Endereco",
                column: "cidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais_paisId",
                table: "Estado",
                column: "paisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidade_Estado_estadoId",
                table: "Cidade");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Cidade_cidadeId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Estado_Pais_paisId",
                table: "Estado");

            migrationBuilder.RenameColumn(
                name: "paisId",
                table: "Estado",
                newName: "PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_Estado_paisId",
                table: "Estado",
                newName: "IX_Estado_PaisId");

            migrationBuilder.RenameColumn(
                name: "cidadeId",
                table: "Endereco",
                newName: "CidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_cidadeId",
                table: "Endereco",
                newName: "IX_Endereco_CidadeId");

            migrationBuilder.RenameColumn(
                name: "estadoId",
                table: "Cidade",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidade_estadoId",
                table: "Cidade",
                newName: "IX_Cidade_EstadoId");

            migrationBuilder.AlterColumn<int>(
                name: "PaisId",
                table: "Estado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CidadeId",
                table: "Endereco",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EstadoId",
                table: "Cidade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidade_Estado_EstadoId",
                table: "Cidade",
                column: "EstadoId",
                principalTable: "Estado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Cidade_CidadeId",
                table: "Endereco",
                column: "CidadeId",
                principalTable: "Cidade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estado_Pais_PaisId",
                table: "Estado",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
