using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.BebidasGeladasService
{
    public interface IBebidasGeladasInterface
    {
        Task<ServiceResponse<List<BebidasGeladasModel>>> GetBebidasGeladas();
        Task<ServiceResponse<List<BebidasGeladasModel>>> CreateBebidasGeladas();
        Task<ServiceResponse<List<BebidasGeladasModel>>> UpdateBebidasGeladas();
        Task<ServiceResponse<List<BebidasGeladasModel>>> DeleteBebidasGeladas();
        Task<ServiceResponse<List<BebidasGeladasModel>>> GetByIdBebidasGeladas(int id);
        Task<ServiceResponse<List<IngredientesModel>>> GetIngredienteByBebidasGeladas(int id);



    }
}
