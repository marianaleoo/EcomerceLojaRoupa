using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceLojaRoupa.Migrations
{
    public partial class MudancaTipoPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValorTotalVenda",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Frete",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ValorTotalVenda",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Frete",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
