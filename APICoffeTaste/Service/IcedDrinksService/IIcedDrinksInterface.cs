using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.IcedDrinksService
{
    public interface IIcedDrinksInterface
    {
        Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinks();
        Task<ServiceResponse<List<IcedDrinksModel>>> CreateIcedDrinks(DtoCreateIcedDrinks icedDrinkCeate);
        Task<ServiceResponse<List<IcedDrinksModel>>> UpdateIcedDrinks(IcedDrinksModel updateIcedDrink);
        Task<ServiceResponse<List<IcedDrinksModel>>> DeleteBebidasGeladas(int id);
        Task<ServiceResponse<IcedDrinksModel>> GetIcedDrinksById(int id);
        Task<ServiceResponse<List<IngredientsIcedDrinksModel>>> GetIngredientsByIcedDrinks(int id);
    }
}
