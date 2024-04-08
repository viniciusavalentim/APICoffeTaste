using APICoffeeTaste.DataContext;
using APICoffeeTaste.Service.IcedDrinksService;
using APICoffeeTaste.Service.CafeService;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.MetodosService;
using APICoffeeTaste.Service.ReceitaService;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddScoped<ICafesInterface, CafesService>();//quando eu quiser fazer uma injeção de dependencia da minha interface, significa que eu vou poder usar os metodos do "metodosService"
            builder.Services.AddScoped<IReceitaInteface, ReceitaService>();//quando eu quiser fazer uma injeção de dependencia da minha interface, significa que eu vou poder usar os metodos do "metodosService"
            builder.Services.AddScoped<IIcedDrinksInterface, IcedDrinksService>();//quando eu quiser fazer uma injeção de dependencia da minha interface, significa que eu vou poder usar os metodos do "metodosService"
            builder.Services.AddScoped<IHotDrinksInterface, HotDrinksService>();//quando eu quiser fazer uma injeção de dependencia da minha interface, significa que eu vou poder usar os metodos do "metodosService"



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