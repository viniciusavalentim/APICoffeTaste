using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class AdicionadoPropriedadeQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Quantidade",
                table: "Ingredientes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ingredientes");
        }
    }
}
