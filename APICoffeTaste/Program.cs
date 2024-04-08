using APICoffeeTaste.DataContext;
using APICoffeeTaste.Service.IcedDrinksService;
using APICoffeeTaste.Service.CafeService;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.MetodosService;
using APICoffeeTaste.Service.ReceitaService;
using Microsoft.EntityFrameworkCore;
using APICoffeeTaste.Service.CoffeeSprintsService;
using APICoffeeTaste.Service.SoftDrinksService;
using APICoffeeTaste.Service.TeasService;

namespace APICoffeeTaste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IMetodosInterface, MetodosService>();//quando eu quiser fazer uma injeção de dependencia da minha interface, significa que eu vou poder usar os metodos do "metodosService"
            builder.Services.AddScoped<ICafesInterface, CafesService>();
            builder.Services.AddScoped<IReceitaInteface, ReceitaService>();
            builder.Services.AddScoped<IIcedDrinksInterface, IcedDrinksService>();
            builder.Services.AddScoped<IHotDrinksInterface, HotDrinksService>();
            builder.Services.AddScoped<ICoffeeSprintsInterface, CoffeeSprintsService>();
            builder.Services.AddScoped<ISoftDrinksInterface, SoftDrinksService>();
            builder.Services.AddScoped<ITeasInterface, TeasService>();




            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"));
            });

            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();
    

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();


            app.Run();
        }
    }
}