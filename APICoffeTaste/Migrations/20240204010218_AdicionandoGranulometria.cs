using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoffeTaste.Migrations
{
    public partial class AdicionandoGranulometria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Granulometria",
                table: "Receitas",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Granulometria",
                table: "Receitas");
        }
    }
}
