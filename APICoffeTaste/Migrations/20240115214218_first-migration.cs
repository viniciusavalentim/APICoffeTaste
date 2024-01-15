using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeTaste.Migrations
{
    public partial class firstmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Metodos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeDeCafe = table.Column<float>(type: "real", nullable: false),
                    QuantidadeDeAgua = table.Column<float>(type: "real", nullable: false),
                    Temperatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metodos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metodos");
        }
    }
}
