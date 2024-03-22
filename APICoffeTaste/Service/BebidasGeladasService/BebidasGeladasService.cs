using APICoffeeTaste.DataContext;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.BebidasGeladasService
{
    public class BebidasGeladasService : IBebidasGeladasInterface
    {
        private readonly ApplicationDbContext _context;
        public BebidasGeladasService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<BebidasGeladasModel>>> GetBebidasGeladas()
        {
           ServiceResponse<List<BebidasGeladasModel>> serviceResponse = new ServiceResponse<List<BebidasGeladasModel>>();
            try
            {
                serviceResponse.Dados = await _context.BebidasGeladas.Include(b => b.Ingredientes).ToListAsync();
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
        public Task<ServiceResponse<List<BebidasGeladasModel>>> GetByIdBebidasGeladas(int id)
        {
            throw new NotImplementedException();
        }




        public Task<ServiceResponse<List<BebidasGeladasModel>>> CreateBebidasGeladas()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<BebidasGeladasModel>>> DeleteBebidasGeladas()
        {
            throw new NotImplementedException();
        }

   
        public Task<ServiceResponse<List<BebidasGeladasModel>>> UpdateBebidasGeladas()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<IngredientesModel>>> GetIngredienteByBebidasGeladas(int id)
        {
            ServiceResponse<List<IngredientesModel>> serviceResponse = new ServiceResponse<List<IngredientesModel>>();
            try
            {
                List<IngredientesModel> ingredientes =  _context.Ingredientes.Where(x => x.BebidasGeladasId == id).ToList();

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
