using APICoffeTaste.DataContext;
using APICoffeTaste.Models;

namespace APICoffeTaste.Service.MetodosService
{
    public class MetodosService : IMetodosInterface
    {
        private readonly ApplicationDbContext _context; //isso é para ter acesso ao banco de dados e atabela que foi criada(nesse caso o metodos)
        public MetodosService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<MetodosModel>>> GetMetodos() //preciso criar um elemento do tipo service response que vai retornar uma lista de metodos
        {
            ServiceResponse<List<MetodosModel>> serviceResponse = new ServiceResponse<List<MetodosModel>>();
            try
            {
                serviceResponse.Dados = _context.Metodos.ToList();
                if(serviceResponse.Dados.Count == 0) 
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
        public async Task<ServiceResponse<List<MetodosModel>>> CreateMetodos(MetodosModel novoMetodo)
        {
            ServiceResponse<List<MetodosModel>> serviceResponse = new ServiceResponse<List<MetodosModel>>();
            try
            {
                if(novoMetodo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados";
                    serviceResponse.Sucesso= false;
                }

                _context.Add(novoMetodo);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Metodos.ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public Task<ServiceResponse<List<MetodosModel>>> DeleteMetodos(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<MetodosModel>> GetMetodoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<MetodosModel>>> UpdateMetodos(MetodosModel updateMetodo)
        {
            throw new NotImplementedException();
        }

    }
}
