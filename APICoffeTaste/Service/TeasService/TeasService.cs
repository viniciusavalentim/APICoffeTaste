using APICoffeeTaste.DataContext;
using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.TeasService
{
    public class TeasService : ITeasInterface
    {
        private readonly ApplicationDbContext _context;
        public TeasService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<IngredientsTeasModel>>> CreateIngredients(DtoCreateIngredients createIngredient, int id)
        {
            ServiceResponse<List<IngredientsTeasModel>> serviceResponse = new ServiceResponse<List<IngredientsTeasModel>>();
            try
            {
                var tea = await _context.Teas.Include(m => m.Ingredientes).FirstOrDefaultAsync(m => m.Id == id);


                if (tea == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Método não encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                List<IngredientsTeasModel> ingredients = new List<IngredientsTeasModel>();


                var newIngredient = new IngredientsTeasModel
                {
                    Name = createIngredient.Name,
                    Quantity = createIngredient.Quantity,
                    Unit = createIngredient.Unit
                };

                ingredients.Add(newIngredient);
                _context.IngredientsTeas.Add(newIngredient);
                // Associa a lista de cafés ao método
                tea?.Ingredientes?.AddRange(ingredients);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = tea?.Ingredientes?.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<TeasModel>>> CreateTeas(DtoCreateTeas CreateTea)
        {
            ServiceResponse<List<TeasModel>> serviceResponse = new ServiceResponse<List<TeasModel>>();
            try
            {
                TeasModel newTea = new TeasModel
                {
                    Name = CreateTea.Name
                };

                List<IngredientsTeasModel> newIngredients = new List<IngredientsTeasModel>();

                foreach (DtoCreateIngredients dtoIngredient in CreateTea.Ingredientes)
                {
                    IngredientsTeasModel newIngredient = new IngredientsTeasModel
                    {
                        Name = dtoIngredient.Name,
                        Quantity = dtoIngredient.Quantity,
                        Unit = dtoIngredient.Unit
                    };

                    newIngredients.Add(newIngredient);
                    _context.IngredientsTeas.Add(newIngredient);
                }

                newTea.Ingredientes = newIngredients;
                if (newTea == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                }

                _context.Teas.Add(newTea);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = await _context.Teas.Include(i => i.Ingredientes).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = true;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<TeasModel>>> DeleteTea(int id)
        {
            ServiceResponse<List<TeasModel>> serviceResponse = new ServiceResponse<List<TeasModel>>();
            try
            {
                TeasModel deleteTea = _context.Teas.FirstOrDefault(x => x.Id == id);
                if (deleteTea == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.Teas.Remove(deleteTea);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Teas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<IngredientsTeasModel>> DeleteIngredient(int id)
        {
            ServiceResponse<IngredientsTeasModel> serviceResponse = new ServiceResponse<IngredientsTeasModel>();
            try
            {
                IngredientsTeasModel deleteIngredient = _context.IngredientsTeas.FirstOrDefault(x => x.Id == id);
                if (deleteIngredient == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.IngredientsTeas.Remove(deleteIngredient);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = deleteIngredient;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<IngredientsTeasModel>>> GetIngredientsByTea(int id)
        {
            ServiceResponse<List<IngredientsTeasModel>> serviceResponse = new ServiceResponse<List<IngredientsTeasModel>>();
            try
            {
                List<IngredientsTeasModel> ingredientes = _context.IngredientsTeas.Where(x => x.TeasId == id).ToList();

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
        public async Task<ServiceResponse<TeasModel>> GetTeaById(int id)
        {
            ServiceResponse<TeasModel> serviceResponse = new ServiceResponse<TeasModel>();
            try
            {
                TeasModel tea = _context.Teas.Include(i => i.Ingredientes).FirstOrDefault(x => x.Id == id);
                if (tea == null)
                {
                    serviceResponse.Mensagem = "Not found!";
                }
                serviceResponse.Dados = tea;
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<TeasModel>>> GetTeas()
        {
            ServiceResponse<List<TeasModel>> serviceResponse = new ServiceResponse<List<TeasModel>>();
            try
            {
                serviceResponse.Dados = await _context.Teas.Include(b => b.Ingredientes).ToListAsync();
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
        public async Task<ServiceResponse<List<TeasModel>>> UpdateTeas(TeasModel updateTea)
        {
            ServiceResponse<List<TeasModel>> serviceResponse = new ServiceResponse<List<TeasModel>>();
            try
            {
                TeasModel updateTeaModel = _context.Teas.AsNoTracking().FirstOrDefault(i => i.Id == updateTea.Id);
                if (updateTeaModel == null)
                {
                    serviceResponse.Mensagem = "Not Found!";
                    serviceResponse.Sucesso = true;
                }
                _context.Teas.Update(updateTea);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Teas.ToList();
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
