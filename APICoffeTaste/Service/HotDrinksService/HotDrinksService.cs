using APICoffeeTaste.Models;

namespace APICoffeeTaste.Service.HotDrinksService
{
    public class HotDrinksService : IHotDrinksInterface
    {
        public Task<ServiceResponse<List<HotDrinksService>>> CreateHotDrinks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksService>>> DeleteHotDrinks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksService>>> GetHotDrinks()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksService>>> GetHotDrinksById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<IngredientsModel>>> GetIngredientByHotDrinksID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<HotDrinksService>>> UpdateHotDrinks()
        {
            throw new NotImplementedException();
        }
    }
}
