using APICoffeeTaste.DataContext;
using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using Microsoft.EntityFrameworkCore;

namespace APICoffeeTaste.Service.CafeService
{
    public class CafesService : ICafesInterface
    {
        private readonly ApplicationDbContext _context; //isso é para ter acesso ao banco de dados e atabela que foi criada(nesse caso o metodos)
        public CafesService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CafesModel>>> CreateCafes(DtoCreateCafe novoCafe, int metodoId)
        {
            ServiceResponse<List<CafesModel>> serviceResponse = new ServiceResponse<List<CafesModel>>();
            try
            {
                var metodo = await _context.Metodos.Include(m => m.Cafes).ThenInclude(c => c.Receita)
                            .FirstOrDefaultAsync(m => m.Id == metodoId);


                if (metodo == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Método não encontrado";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                var cafes = new List<CafesModel>();

                    var cafe = new CafesModel
                    {
                        Variacao = novoCafe.Variacao,
                    };

                    var novaReceita = new ReceitasModel
                    {
                        QuantidadeDeCafe = novoCafe.Receita?.QuantidadeDeCafe ?? 0,
                        QuantidadeDeAgua = novoCafe.Receita?.QuantidadeDeAgua ?? 0,
                        Temperatura = novoCafe.Receita?.Temperatura ?? 0,
                        Granulometria = novoCafe.Receita?.Granulometria ?? 0,
                        Cafe = cafe
                    };

                    cafe.Receita = novaReceita;

                    // Adiciona cada café à lista
                    cafes.Add(cafe);

                    // Adiciona café e receita ao contexto
                    _context.Cafes.Add(cafe);
                    _context.Receitas.Add(novaReceita);
                // Associa a lista de cafés ao método
                metodo.Cafes.AddRange(cafes);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = metodo.Cafes.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
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
