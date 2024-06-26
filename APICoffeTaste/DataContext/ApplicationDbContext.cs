﻿using APICoffeeTaste.Models;
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
        public DbSet<TeasModel> Teas { get; set; }
        public DbSet<SoftDrinksModel> SoftDrinks { get; set; }
        public DbSet<CoffeeSprintsModel> CoffeeSprints { get; set; }

        public DbSet<IngredientsIcedDrinksModel> IngredientesIcedDrinks { get; set; }
        public DbSet<IngredientsHotDrinksModel> IngredientesHotDrinks { get; set; }
        public DbSet<IngredientsTeasModel> IngredientsTeas { get; set; }
        public DbSet<IngredientsSoftDrinksModel> IngredientsSoftDrinks { get; set; }
        public DbSet<IngredientsCoffeeSprintsModel> IngredientsCoffeeSprints { get; set; }

    }
}
