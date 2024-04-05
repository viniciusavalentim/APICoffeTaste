using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class CreateRelacaoComICedDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IcedDrinksId",
                table: "Ingredientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IcedDrinksId",
                table: "Ingredientes",
                column: "IcedDrinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksId",
                table: "Ingredientes",
                column: "IcedDrinksId",
                principalTable: "IcedDrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_IcedDrinksId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "IcedDrinksId",
                table: "Ingredientes");
        }
    }
}
