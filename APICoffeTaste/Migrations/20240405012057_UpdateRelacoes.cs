using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class UpdateRelacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcedDrinks_Ingredientes_IngredientsId",
                table: "IcedDrinks");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_HotDrinks_HotDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_HotDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_Ingredientes_IcedDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropIndex(
                name: "IX_IcedDrinks_IngredientsId",
                table: "IcedDrinks");

            migrationBuilder.DropColumn(
                name: "HotDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "IcedDrinksModelId",
                table: "Ingredientes");

            migrationBuilder.DropColumn(
                name: "IngredientsId",
                table: "IcedDrinks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotDrinksModelId",
                table: "Ingredientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IcedDrinksModelId",
                table: "Ingredientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientsId",
                table: "IcedDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_HotDrinksModelId",
                table: "Ingredientes",
                column: "HotDrinksModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IcedDrinksModelId",
                table: "Ingredientes",
                column: "IcedDrinksModelId");

            migrationBuilder.CreateIndex(
                name: "IX_IcedDrinks_IngredientsId",
                table: "IcedDrinks",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IcedDrinks_Ingredientes_IngredientsId",
                table: "IcedDrinks",
                column: "IngredientsId",
                principalTable: "Ingredientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_HotDrinks_HotDrinksModelId",
                table: "Ingredientes",
                column: "HotDrinksModelId",
                principalTable: "HotDrinks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredientes_IcedDrinks_IcedDrinksModelId",
                table: "Ingredientes",
                column: "IcedDrinksModelId",
                principalTable: "IcedDrinks",
                principalColumn: "Id");
        }
    }
}
