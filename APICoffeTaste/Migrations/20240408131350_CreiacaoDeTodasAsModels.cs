using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class CreiacaoDeTodasAsModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoffeeSprints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeSprints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsCoffeeSprints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoffeeSprintsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsCoffeeSprints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsCoffeeSprints_CoffeeSprints_CoffeeSprintsId",
                        column: x => x.CoffeeSprintsId,
                        principalTable: "CoffeeSprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsSoftDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDrinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsSoftDrinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsSoftDrinks_SoftDrinks_SoftDrinksId",
                        column: x => x.SoftDrinksId,
                        principalTable: "SoftDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsTeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsTeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientsTeas_Teas_TeasId",
                        column: x => x.TeasId,
                        principalTable: "Teas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsCoffeeSprints_CoffeeSprintsId",
                table: "IngredientsCoffeeSprints",
                column: "CoffeeSprintsId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsSoftDrinks_SoftDrinksId",
                table: "IngredientsSoftDrinks",
                column: "SoftDrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsTeas_TeasId",
                table: "IngredientsTeas",
                column: "TeasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsCoffeeSprints");

            migrationBuilder.DropTable(
                name: "IngredientsSoftDrinks");

            migrationBuilder.DropTable(
                name: "IngredientsTeas");

            migrationBuilder.DropTable(
                name: "CoffeeSprints");

            migrationBuilder.DropTable(
                name: "SoftDrinks");

            migrationBuilder.DropTable(
                name: "Teas");
        }
    }
}
