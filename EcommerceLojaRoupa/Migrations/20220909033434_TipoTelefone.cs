using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class TipoTelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DDD",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoTelefoneId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TipoTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTelefone", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoTelefoneId",
                table: "Cliente",
                column: "TipoTelefoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoTelefone_TipoTelefoneId",
                table: "Cliente",
                column: "TipoTelefoneId",
                principalTable: "TipoTelefone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoTelefone_TipoTelefoneId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoTelefone");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_TipoTelefoneId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "DDD",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "TipoTelefoneId",
                table: "Cliente");
        }
    }
}
