using APICoffeeTaste.DataContext;
using APICoffeeTaste.Dtos;
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
        public async Task<ServiceResponse<HotDrinksModel>> GetHotDrinksById(int id)
        {
            ServiceResponse<HotDrinksModel> serviceResponse = new ServiceResponse<HotDrinksModel>();
            try
            {
                HotDrinksModel IcedDrink = _context.HotDrinks.Include(i => i.Ingredientes).FirstOrDefault(x => x.Id == id);
                if (IcedDrink == null)
                {
                    serviceResponse.Mensagem = "Not found!";
                }
                serviceResponse.Dados = IcedDrink;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<IngredientsHotDrinksModel>>> GetIngredientsByHotDrinks(int id)
        {
            ServiceResponse<List<IngredientsHotDrinksModel>> serviceResponse = new ServiceResponse<List<IngredientsHotDrinksModel>>();
            try
            {
                List<IngredientsHotDrinksModel> ingredientes = _context.IngredientesHotDrinks.Where(x => x.HotDrinksId == id).ToList();

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
        public async Task<ServiceResponse<List<HotDrinksModel>>> CreateHotDrinks(DtoCreateHotDrinks createHotDrinks)
        {
            ServiceResponse<List<HotDrinksModel>> serviceResponse = new ServiceResponse<List<HotDrinksModel>>();
            try
            {
                HotDrinksModel newHotDrink = new HotDrinksModel
                {
                    Name = createHotDrinks.Name
                };

                List<IngredientsHotDrinksModel> newIngredients = new List<IngredientsHotDrinksModel>();

                foreach (var dtoIngredient in createHotDrinks.Ingredientes)
                {
                    IngredientsHotDrinksModel newIngredient = new IngredientsHotDrinksModel
                    {
                        Name = dtoIngredient.Name,
                        Quantity = dtoIngredient.Quantity,
                        Unit = dtoIngredient.Unit
                    };

                    newIngredients.Add(newIngredient);
                    _context.IngredientesHotDrinks.Add(newIngredient);
                }

                newHotDrink.Ingredientes = newIngredients;
                if (newHotDrink == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                }

                _context.HotDrinks.Add(newHotDrink);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = await _context.HotDrinks.Include(i => i.Ingredientes).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<HotDrinksModel>>> UpdateHotDrinks(HotDrinksModel updateHotDrinks)
        {
            ServiceResponse<List<HotDrinksModel>> serviceResponse = new ServiceResponse<List<HotDrinksModel>>();
            try
            {
                HotDrinksModel updateHotDrinksModel = _context.HotDrinks.AsNoTracking().FirstOrDefault(i => i.Id == updateHotDrinks.Id);
                if (updateHotDrinksModel == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.HotDrinks.Update(updateHotDrinks);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.HotDrinks.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<HotDrinksModel>>> DeleteHotDrinks(int id)
        {
            ServiceResponse<List<HotDrinksModel>> serviceResponse = new ServiceResponse<List<HotDrinksModel>>();
            try
            {
                HotDrinksModel deleteHotDrink = _context.HotDrinks.FirstOrDefault(x => x.Id == id);
                if (deleteHotDrink == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.HotDrinks.Remove(deleteHotDrink);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.HotDrinks.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<IngredientsHotDrinksModel>>> CreateIngredients(DtoCreateIngredients createIngredient, int id)
        {
            ServiceResponse<List<IngredientsHotDrinksModel>> serviceResponse = new ServiceResponse<List<IngredientsHotDrinksModel>>();
            try
            {
                var hotDrinks = await _context.HotDrinks.Include(m => m.Ingredientes).FirstOrDefaultAsync(m => m.Id == id);


                if (hotDrinks == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Método não encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                List<IngredientsHotDrinksModel> ingredients = new List<IngredientsHotDrinksModel>();


                var newIngredient = new IngredientsHotDrinksModel
                {
                    Name = createIngredient.Name,
                    Quantity = createIngredient.Quantity,
                    Unit = createIngredient.Unit
                };

                ingredients.Add(newIngredient);
                _context.IngredientesHotDrinks.Add(newIngredient);
                // Associa a lista de cafés ao método
                hotDrinks?.Ingredientes?.AddRange(ingredients);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = hotDrinks?.Ingredientes?.ToList();
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