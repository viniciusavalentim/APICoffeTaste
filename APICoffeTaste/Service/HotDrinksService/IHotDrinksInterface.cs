using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.HotDrinksService
{
    public interface IHotDrinksInterface
    {
        Task<ServiceResponse<List<HotDrinksModel>>> GetHotDrinks();
        Task<ServiceResponse<List<HotDrinksModel>>> CreateHotDrinks();
        Task<ServiceResponse<List<HotDrinksModel>>> UpdateHotDrinks();
        Task<ServiceResponse<List<HotDrinksModel>>> DeleteHotDrinks();
        Task<ServiceResponse<List<HotDrinksModel>>> GetHotDrinksById(int id);
        Task<ServiceResponse<List<IngredientsIcedDrinksModel>>> GetIngredientByHotDrinksID(int id);
    }
}
