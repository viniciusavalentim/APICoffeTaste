using APICoffeeTaste.DataContext;
using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.CoffeeSprintsService
{
    public class CoffeeSprintsService : ICoffeeSprintsInterface
    {
        private readonly ApplicationDbContext _context;
        public CoffeeSprintsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<CoffeeSprintsModel>>> CreateCoffeeSprints(DtoCreateCoffeeSprints createCoffeeSprint)
        {
            ServiceResponse<List<CoffeeSprintsModel>> serviceResponse = new ServiceResponse<List<CoffeeSprintsModel>>();
            try
            {
                CoffeeSprintsModel newTea = new CoffeeSprintsModel
                {
                    Name = createCoffeeSprint.Name
                };

                List<IngredientsCoffeeSprintsModel> newIngredients = new List<IngredientsCoffeeSprintsModel>();

                foreach (DtoCreateIngredients dtoIngredient in createCoffeeSprint.Ingredientes)
                {
                    IngredientsCoffeeSprintsModel newIngredient = new IngredientsCoffeeSprintsModel
                    {
                        Name = dtoIngredient.Name,
                        Quantity = dtoIngredient.Quantity,
                        Unit = dtoIngredient.Unit
                    };

                    newIngredients.Add(newIngredient);
                    _context.IngredientsCoffeeSprints.Add(newIngredient);
                }

                newTea.Ingredientes = newIngredients;
                if (newTea == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                }

                _context.CoffeeSprints.Add(newTea);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = await _context.CoffeeSprints.Include(i => i.Ingredientes).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CoffeeSprintsModel>>> DeleteCoffeeSprints(int id)
        {
            ServiceResponse<List<CoffeeSprintsModel>> serviceResponse = new ServiceResponse<List<CoffeeSprintsModel>>();
            try
            {
                CoffeeSprintsModel deleteTea = _context.CoffeeSprints.FirstOrDefault(x => x.Id == id);
                if (deleteTea == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.CoffeeSprints.Remove(deleteTea);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.CoffeeSprints.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CoffeeSprintsModel>>> GetCoffeeSprints()
        {
            ServiceResponse<List<CoffeeSprintsModel>> serviceResponse = new ServiceResponse<List<CoffeeSprintsModel>>();
            try
            {
                serviceResponse.Dados = await _context.CoffeeSprints.Include(b => b.Ingredientes).ToListAsync();
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

        public async Task<ServiceResponse<CoffeeSprintsModel>> GetCoffeeSprintsById(int id)
        {
            ServiceResponse<CoffeeSprintsModel> serviceResponse = new ServiceResponse<CoffeeSprintsModel>();
            try
            {
                CoffeeSprintsModel coffeeSprint = _context.CoffeeSprints.Include(i => i.Ingredientes).FirstOrDefault(x => x.Id == id);
                if (coffeeSprint == null)
                {
                    serviceResponse.Mensagem = "Not found!";
                }
                serviceResponse.Dados = coffeeSprint;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<IngredientsCoffeeSprintsModel>>> GetIngredientsByCoffeeSprintId(int id)
        {
            ServiceResponse<List<IngredientsCoffeeSprintsModel>> serviceResponse = new ServiceResponse<List<IngredientsCoffeeSprintsModel>>();
            try
            {
                List<IngredientsCoffeeSprintsModel> ingredientes = _context.IngredientsCoffeeSprints.Where(x => x.CoffeeSprintsId == id).ToList();

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

        public async Task<ServiceResponse<List<CoffeeSprintsModel>>> UpdateCoffeeSprints(CoffeeSprintsModel updateCofeeSprints)
        {
            ServiceResponse<List<CoffeeSprintsModel>> serviceResponse = new ServiceResponse<List<CoffeeSprintsModel>>();
            try
            {
                CoffeeSprintsModel updateCoffeeSprintModel = _context.CoffeeSprints.AsNoTracking().FirstOrDefault(i => i.Id == updateCofeeSprints.Id);
                if (updateCoffeeSprintModel == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.CoffeeSprints.Update(updateCofeeSprints);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.CoffeeSprints.ToList();
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
