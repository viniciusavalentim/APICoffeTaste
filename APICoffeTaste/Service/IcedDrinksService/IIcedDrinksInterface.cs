using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.BebidasGeladasService
{
    public interface IIcedDrinksInterface
    {
        Task<ServiceResponse<List<IcedDrinksModel>>> GetIcedDrinks();
        Task<ServiceResponse<List<IcedDrinksModel>>> CreateBebidasGeladas();
        Task<ServiceResponse<List<IcedDrinksModel>>> UpdateBebidasGeladas();
        Task<ServiceResponse<List<IcedDrinksModel>>> DeleteBebidasGeladas();
        Task<ServiceResponse<List<IcedDrinksModel>>> GetByIdBebidasGeladas(int id);
        Task<ServiceResponse<List<IngredientsModel>>> GetIngredientsByIcedDrinks(int id);
    }
}
