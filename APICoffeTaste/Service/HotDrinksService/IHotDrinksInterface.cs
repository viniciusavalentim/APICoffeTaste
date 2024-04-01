using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.HotDrinksService
{
    public interface IHotDrinksInterface
    {
        Task<ServiceResponse<List<HotDrinksService>>> GetHotDrinks();
        Task<ServiceResponse<List<HotDrinksService>>> CreateHotDrinks();
        Task<ServiceResponse<List<HotDrinksService>>> UpdateHotDrinks();
        Task<ServiceResponse<List<HotDrinksService>>> DeleteHotDrinks();
        Task<ServiceResponse<List<HotDrinksService>>> GetHotDrinksById(int id);
        Task<ServiceResponse<List<IngredientsModel>>> GetIngredientByHotDrinksID(int id);
    }
}
