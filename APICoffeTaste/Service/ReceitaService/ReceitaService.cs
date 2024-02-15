using APICoffeTaste.DataContext;
using APICoffeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeTaste.Service.ReceitaService
{
    public class ReceitaService : IReceitaInteface
    {
        private readonly ApplicationDbContext _context; //isso é para ter acesso ao banco de dados e atabela que foi criada(nesse caso o metodos)
        public ReceitaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<ReceitasModel>>> GetReceita()
        {
            ServiceResponse<List<ReceitasModel>> serviceResponse = new ServiceResponse<List<ReceitasModel>>();
            try
            {
                serviceResponse.Dados = await _context.Receitas.ToListAsync();
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
        
        public async Task<ServiceResponse<List<ReceitasModel>>> GetReceitaByCafe(int cafeId)
        {
            ServiceResponse<List<ReceitasModel>> serviceResponse = new ServiceResponse<List<ReceitasModel>>();
            try
            {
                List<ReceitasModel> receita =  _context.Receitas.Where(x => x.CafeId == cafeId).ToList();

                if (receita == null)
                {
                    serviceResponse.Mensagem = "Nenhum dado foi encontrado";
                }

                serviceResponse.Dados = receita;
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
