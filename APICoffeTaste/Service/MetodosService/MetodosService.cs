using APICoffeTaste.DataContext;
using APICoffeTaste.Dtos;
using APICoffeTaste.Models;
using Microsoft.EntityFrameworkCore;

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
                serviceResponse.Dados = await _context.Metodos.Include(m => m.Cafes).ThenInclude(c => c.Receita).ToListAsync();
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
        public async Task<ServiceResponse<List<MetodosModel>>> CreateMetodos(DtoCreateMetodo metodo)
        {
            ServiceResponse<List<MetodosModel>> serviceResponse = new ServiceResponse<List<MetodosModel>>();
            try
            {
                var novoMetodo = new MetodosModel
                {
                    Metodos = metodo.Metodos
                };
                // Lista para armazenar os cafés criados
                var cafes = new List<CafesModel>();
                foreach (var cafeDto in metodo.Cafes)
                {
                    var novoCafe = new CafesModel
                    {
                        Variacao = cafeDto.Variacao,
                        Metodo = novoMetodo
                    };

                    var novaReceita = new ReceitasModel
                    {
                        QuantidadeDeCafe = cafeDto.Receita?.QuantidadeDeCafe ?? 0,
                        QuantidadeDeAgua = cafeDto.Receita?.QuantidadeDeAgua ?? 0,
                        Temperatura = cafeDto.Receita?.Temperatura ?? 0,
                        Granulometria = cafeDto.Receita?.Granulometria ?? 0,
                        Cafe = novoCafe
                    };

                    novoCafe.Receita = novaReceita;

                    // Adiciona cada café à lista
                    cafes.Add(novoCafe);

                    // Adiciona café e receita ao contexto
                    _context.Cafes.Add(novoCafe);
                    _context.Receitas.Add(novaReceita);
                }
                // Associa a lista de cafés ao método
                novoMetodo.Cafes = cafes;

                // Retorna os métodos incluindo cafés e receitas

                if (novoMetodo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados";
                    serviceResponse.Sucesso= false;
                }

                _context.Metodos.Add(novoMetodo);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = await _context.Metodos.Include(m => m.Cafes).ThenInclude(c => c.Receita).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<MetodosModel>> GetMetodoById(int id)
        {
            ServiceResponse<MetodosModel> serviceResponse = new ServiceResponse<MetodosModel>();
            try
            {
                MetodosModel metodos = _context.Metodos.Include(x => x.Cafes).FirstOrDefault(x => x.Id == id); //verificação / x = metodomodel que tem dentro do banco && faço o x.(todas as propriedades)id == (igual) id que eu recebi(acho q é como se fosse where)

                if (metodos == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Id nao encontrado";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = metodos;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<List<MetodosModel>>> UpdateMetodos(MetodosModel updateMetodo)
        {
            ServiceResponse<List<MetodosModel>> serviceResponse = new ServiceResponse<List<MetodosModel>>();
            try
            {
                MetodosModel metodos = _context.Metodos.AsNoTracking().FirstOrDefault(x => x.Id == updateMetodo.Id);
                if (metodos == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Variacao nao encontrada";
                    serviceResponse.Sucesso = false;
                }

                _context.Metodos.Update(updateMetodo);
                await _context.SaveChangesAsync();  
                serviceResponse.Dados = _context.Metodos.ToList();  

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso= false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<List<MetodosModel>>> DeleteMetodos(int id)
        {
            ServiceResponse<List<MetodosModel>> serviceResponse = new ServiceResponse<List<MetodosModel>>();
            try
            {
                MetodosModel metodos = _context.Metodos.FirstOrDefault(x => x.Id == id);
                if (metodos == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário nao encontrada";
                    serviceResponse.Sucesso = false;
                }
                _context.Metodos.Remove(metodos);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Metodos.ToList();

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
