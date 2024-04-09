using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.CoffeeSprintsService
{
    public interface ICoffeeSprintsInterface
    {
        Task<ServiceResponse<List<CoffeeSprintsModel>>> GetCoffeeSprints();
        Task<ServiceResponse<List<CoffeeSprintsModel>>> CreateCoffeeSprints(DtoCreateCoffeeSprints createTeas);
        Task<ServiceResponse<List<CoffeeSprintsModel>>> UpdateCoffeeSprints(CoffeeSprintsModel updateTea);
        Task<ServiceResponse<List<CoffeeSprintsModel>>> DeleteCoffeeSprints(int id);
        Task<ServiceResponse<CoffeeSprintsModel>> GetCoffeeSprintsById(int id);
        Task<ServiceResponse<List<IngredientsCoffeeSprintsModel>>> GetIngredientsByCoffeeSprintId(int id);
    }
}
}
