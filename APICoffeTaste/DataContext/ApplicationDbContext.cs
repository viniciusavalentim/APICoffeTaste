using APICoffeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeTaste.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<MetodosModel> Metodos { get; set; }
        public DbSet<CafesModel> Cafes { get; set; }
        public DbSet<ReceitasModel> Receitas { get; set; }



    }
}
