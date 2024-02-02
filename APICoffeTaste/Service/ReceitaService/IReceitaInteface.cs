using APICoffeTaste.Models;

namespace APICoffeTaste.Service.ReceitaService
{
    public interface IReceitaInteface
    {
        Task<ServiceResponse<List<ReceitasModel>>> GetReceita();
        Task<ServiceResponse<List<ReceitasModel>>> GetReceitaByCafe(int cafeId);


    }
}
