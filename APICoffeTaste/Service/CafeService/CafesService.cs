using APICoffeTaste.DataContext;
using APICoffeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeTaste.Service.CafeService
{
    public class CafesService : ICafesInterface
    {
        private readonly ApplicationDbContext _context; //isso é para ter acesso ao banco de dados e atabela que foi criada(nesse caso o metodos)
        public CafesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CafesModel>>> GetCafes()
        {
            ServiceResponse<List<CafesModel>> serviceResponse = new ServiceResponse<List<CafesModel>>();
            try
            {
                serviceResponse.Dados = await _context.Cafes.ToListAsync();
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
        public async Task<ServiceResponse<List<CafesModel>>> GetCafesByMetodo(int metodoId)
        {
            ServiceResponse<List<CafesModel>> serviceResponse = new ServiceResponse<List<CafesModel>>();
            try
            {
                var cafes = await _context.Cafes.Where(c => c.MetodoId == metodoId).ToListAsync();

                if (cafes == null || cafes.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado";
                }

                serviceResponse.Dados = cafes;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }


        public async Task<ServiceResponse<List<CafesModel>>> GetCafeByVariacao(string variacao)
        {
            ServiceResponse<List<CafesModel>> serviceResponse = new ServiceResponse<List<CafesModel>>();
            try
            {
                List<CafesModel> variacaoMetodos = _context.Cafes.Where(x => x.Variacao == variacao).ToList();

                if (variacaoMetodos == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Variacao nao encontrada";
                    serviceResponse.Sucesso = false;
                }
                else
                {
                    serviceResponse.Dados = variacaoMetodos;

                }

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
