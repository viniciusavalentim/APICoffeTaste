using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeeTaste.Migrations
{
    public partial class CreateFullProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IcedDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcedDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IcedDrinksId = table.Column<int>(type: "int", nullable: false),
                    HotDrinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredientes_HotDrinks_HotDrinksId",
                        column: x => x.HotDrinksId,
                        principalTable: "HotDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredientes_IcedDrinks_IcedDrinksId",
                        column: x => x.IcedDrinksId,
                        principalTable: "IcedDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_HotDrinksId",
                table: "Ingredientes",
                column: "HotDrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_IcedDrinksId",
                table: "Ingredientes",
                column: "IcedDrinksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "HotDrinks");

            migrationBuilder.DropTable(
                name: "IcedDrinks");
        }
    }
}
