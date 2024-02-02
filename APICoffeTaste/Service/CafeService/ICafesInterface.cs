using APICoffeTaste.Dtos;
using APICoffeTaste.Models;

namespace APICoffeTaste.Service.CafeService
{
    public interface ICafesInterface
    {
        Task<ServiceResponse<List<CafesModel>>> GetCafes();
        Task<ServiceResponse<List<CafesModel>>> GetCafesByMetodo(int metodoId);
        Task<ServiceResponse<List<CafesModel>>> GetCafeByVariacao(string variacao);

    }
}
