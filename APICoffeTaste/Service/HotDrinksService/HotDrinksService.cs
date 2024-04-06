using APICoffeeTaste.DataContext;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.HotDrinksService
{
    public class HotDrinksService : IHotDrinksInterface
    {
        private readonly ApplicationDbContext _context;
        public HotDrinksService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<HotDrinksModel>>> GetHotDrinks()
        {
            ServiceResponse<List<HotDrinksModel>> serviceResponse = new ServiceResponse<List<HotDrinksModel>>();
            try
            {
                serviceResponse.Dados = await _context.HotDrinks.Include(b => b.Ingredientes).ToListAsync();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<HotDrinksModel>>> CreateHotDrinks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksModel>>> DeleteHotDrinks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksModel>>> GetHotDrinksById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<IngredientsIcedDrinksModel>>> GetIngredientByHotDrinksID(int id)
        {
            ServiceResponse<List<IngredientsIcedDrinksModel>> serviceResponse = new ServiceResponse<List<IngredientsIcedDrinksModel>>();
            try
            {
                //List<IngredientsIcedDrinksModel> ingredientes = _context.Ingredientes.Where(x => x.HotDrinksId == id).ToList();

                //if (ingredientes == null)
                //{
                //    serviceResponse.Mensagem = "Nenhum dado foi encontrado";
                //}

                //serviceResponse.Dados = ingredientes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<HotDrinksModel>>> UpdateHotDrinks()
        {
            throw new NotImplementedException();
        }
    }
}