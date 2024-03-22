using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.CafeService
{
    public interface ICafesInterface
    {
        Task<ServiceResponse<List<CafesModel>>> CreateCafes(DtoCreateCafe novoCafe, int metodoId);
        Task<ServiceResponse<List<CafesModel>>> GetCafes();
        Task<ServiceResponse<List<CafesModel>>> GetCafesByMetodo(int metodoId);
        Task<ServiceResponse<List<CafesModel>>> GetCafeByVariacao(string variacao);

    }
}
