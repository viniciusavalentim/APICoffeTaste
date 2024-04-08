using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class adcionandoIngredientsHotDrinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsHotDrinksModel_HotDrinks_HotDrinksId",
                table: "IngredientsHotDrinksModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsHotDrinksModel",
                table: "IngredientsHotDrinksModel");

            migrationBuilder.RenameTable(
                name: "IngredientsHotDrinksModel",
                newName: "IngredientesHotDrinks");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsHotDrinksModel_HotDrinksId",
                table: "IngredientesHotDrinks",
                newName: "IX_IngredientesHotDrinks_HotDrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientesHotDrinks",
                table: "IngredientesHotDrinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientesHotDrinks_HotDrinks_HotDrinksId",
                table: "IngredientesHotDrinks",
                column: "HotDrinksId",
                principalTable: "HotDrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientesHotDrinks_HotDrinks_HotDrinksId",
                table: "IngredientesHotDrinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientesHotDrinks",
                table: "IngredientesHotDrinks");

            migrationBuilder.RenameTable(
                name: "IngredientesHotDrinks",
                newName: "IngredientsHotDrinksModel");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientesHotDrinks_HotDrinksId",
                table: "IngredientsHotDrinksModel",
                newName: "IX_IngredientsHotDrinksModel_HotDrinksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsHotDrinksModel",
                table: "IngredientsHotDrinksModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsHotDrinksModel_HotDrinks_HotDrinksId",
                table: "IngredientsHotDrinksModel",
                column: "HotDrinksId",
                principalTable: "HotDrinks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
