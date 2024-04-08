using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class UpdateNameIngredientsIcedDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksId",
                table: "Ingredientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes");

            migrationBuilder.RenameTable(
                name: "Ingredientes",
                newName: "IngredientesIcedDrinks");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredientes_IcedDrinksId",
                table: "IngredientesIcedDrinks",
                newName: "IX_IngredientesIcedDrinks_IcedDrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientesIcedDrinks",
                table: "IngredientesIcedDrinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesIcedDrinks_IcedDrinks_IcedDrinksId",
                table: "IngredientesIcedDrinks",
                column: "IcedDrinksId",
                principalTable: "IcedDrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesIcedDrinks_IcedDrinks_IcedDrinksId",
                table: "IngredientesIcedDrinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientesIcedDrinks",
                table: "IngredientesIcedDrinks");

            migrationBuilder.RenameTable(
                name: "IngredientesIcedDrinks",
                newName: "Ingredientes");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientesIcedDrinks_IcedDrinksId",
                table: "Ingredientes",
                newName: "IX_Ingredientes_IcedDrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredientes",
                table: "Ingredientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksId",
                table: "Ingredientes",
                column: "IcedDrinksId",
                principalTable: "IcedDrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
