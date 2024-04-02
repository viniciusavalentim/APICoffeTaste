using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MetodosModel> Metodos { get; set; }
        public DbSet<CafesModel> Cafes { get; set; }
        public DbSet<ReceitasModel> Receitas { get; set; }
        public DbSet<IcedDrinksModel> IcedDrinks { get; set; }
        public DbSet<HotDrinksModel> HotDrinks { get; set; }
        public DbSet<IngredientsModel> Ingredientes { get; set; }


    }
}
