using APICoffeeTaste.DataContext;
using APICoffeeTaste.Dtos;
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
        public async Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinksById(int id)
        {
            ServiceResponse<List<IcedDrinksModel>> serviceResponse = new ServiceResponse<List<IcedDrinksModel>>();
            try
            {
                List<IcedDrinksModel> IcedDrink = _context.IcedDrinks.Where(x => x.Id == id).ToList();
                if (IcedDrink.Count == 0)
                {
                    serviceResponse.Mensagem = "Not found!";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<IcedDrinksModel>>> CreateIcedDrinks(DtoCreateIcedDrinks icedDrinkCeate)
        {
            ServiceResponse<List<IcedDrinksModel>> serviceResponse = new ServiceResponse<List<IcedDrinksModel>>();
            try
            {
                IcedDrinksModel newIcedDrink = new IcedDrinksModel
                {
                    Name = icedDrinkCeate.Name
                };

                List<IngredientsIcedDrinksModel> newIngredients = new List<IngredientsIcedDrinksModel>();

                foreach (DtoCreateIngredients dtoIngredient in icedDrinkCeate.Ingredientes)
                {
                    IngredientsIcedDrinksModel newIngredient = new IngredientsIcedDrinksModel
                    {
                        Name = dtoIngredient.Name,
                        Quantity = dtoIngredient.Quantity,
                        Unit = dtoIngredient.Unit
                    };

                    newIngredients.Add(newIngredient);
                    _context.IngredientesIcedDrinks.Add(newIngredient);
                }

                newIcedDrink.Ingredientes = newIngredients;
                if (newIcedDrink == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                }

                _context.IcedDrinks.Add(newIcedDrink);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = await _context.IcedDrinks.Include(i => i.Ingredientes).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<List<IcedDrinksModel>>> DeleteBebidasGeladas()
        {
            throw new NotImplementedException();
        }
        public Task<ServiceResponse<List<IcedDrinksModel>>> UpdateBebidasGeladas()
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<List<IngredientsIcedDrinksModel>>> GetIngredientsByIcedDrinks(int id)
        {
            ServiceResponse<List<IngredientsIcedDrinksModel>> serviceResponse = new ServiceResponse<List<IngredientsIcedDrinksModel>>();
            try
            {
                List<IngredientsIcedDrinksModel> ingredientes = _context.IngredientesIcedDrinks.Where(x => x.IcedDrinksId == id).ToList();

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
