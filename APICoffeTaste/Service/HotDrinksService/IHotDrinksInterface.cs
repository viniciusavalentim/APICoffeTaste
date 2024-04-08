using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.HotDrinksService
{
    public interface IHotDrinksInterface
    {
        Task<ServiceResponse<List<HotDrinksModel>>> GetHotDrinks();
        Task<ServiceResponse<List<HotDrinksModel>>> CreateHotDrinks(DtoCreateHotDrinks createHotDrinks);
        Task<ServiceResponse<List<HotDrinksModel>>> UpdateHotDrinks(HotDrinksModel updateHotDrinks);
        Task<ServiceResponse<List<HotDrinksModel>>> DeleteHotDrinks(int id);
        Task<ServiceResponse<HotDrinksModel>> GetHotDrinksById(int id);
        Task<ServiceResponse<List<IngredientsHotDrinksModel>>> GetIngredientsByHotDrinks(int id);
    }
}
