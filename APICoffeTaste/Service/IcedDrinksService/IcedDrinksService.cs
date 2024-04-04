using APICoffeeTaste.DataContext;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.BebidasGeladasService
{
    public class IcedDrinksService : IIcedDrinksInterface
    {
        private readonly ApplicationDbContext _context;
        public IcedDrinksService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinks()
        {
           ServiceResponse<List<IcedDrinksModel>> serviceResponse = new ServiceResponse<List<IcedDrinksModel>>();
            try
            {
                serviceResponse.Dados = await _context.IcedDrinks.Include(b => b.Ingredientes).ToListAsync();
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
        public Task<ServiceResponse<List<IcedDrinksModel>>> GetByIdBebidasGeladas(int id)
        {
            throw new NotImplementedException();
        }


        public Task<ServiceResponse<List<IcedDrinksModel>>> CreateBebidasGeladas()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<IcedDrinksModel>>> DeleteBebidasGeladas()
        {
            throw new NotImplementedException();
        }

   
        public Task<ServiceResponse<List<IcedDrinksModel>>> UpdateBebidasGeladas()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<List<IngredientsModel>>> GetIngredientsByIcedDrinks(int id)
        {
            ServiceResponse<List<IngredientsModel>> serviceResponse = new ServiceResponse<List<IngredientsModel>>();
            try
            {
                List<IngredientsModel> ingredientes =  _context.Ingredientes.Where(x => x.IcedDrinksId == id).ToList();

                if (ingredientes == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado";
                }

                serviceResponse.Dados = ingredientes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
