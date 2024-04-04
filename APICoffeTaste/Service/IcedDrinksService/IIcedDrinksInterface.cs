using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.BebidasGeladasService
{
    public interface IIcedDrinksInterface
    {
        Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinks();
        Task<ServiceResponse<List<IcedDrinksModel>>> CreateIcedDrinks(DtoCreateIcedDrinks icedDrinkCeate);
        Task<ServiceResponse<List<IcedDrinksModel>>> UpdateBebidasGeladas();
        Task<ServiceResponse<List<IcedDrinksModel>>> DeleteBebidasGeladas();
        Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinksById(int id);
        Task<ServiceResponse<List<IngredientsModel>>> GetIngredientsByIcedDrinks(int id);
    }
}
