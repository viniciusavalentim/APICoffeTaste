using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.TeasService
{
    public interface ITeasInterface
    {
        Task<ServiceResponse<List<TeasModel>>> GetTeas();
        Task<ServiceResponse<List<TeasModel>>> CreateTeas(DtoCreateTeas createTeas);
        Task<ServiceResponse<List<TeasModel>>> UpdateTeas(TeasModel updateTea);
        Task<ServiceResponse<List<TeasModel>>> DeleteTea(int id);
        Task<ServiceResponse<IngredientsTeasModel>> DeleteIngredient(int id);
        Task<ServiceResponse<TeasModel>> GetTeaById(int id);
        Task<ServiceResponse<List<IngredientsTeasModel>>> GetIngredientsByTea(int id);
        Task<ServiceResponse<List<IngredientsTeasModel>>>CreateIngredients(DtoCreateIngredients createIngredient, int id);
    }
}
