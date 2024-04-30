using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.IcedDrinksService;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcedDrinksController : ControllerBase
    {
        private readonly IIcedDrinksInterface _IcedDrinksInterface;
        public IcedDrinksController(IIcedDrinksInterface bebidasGeladasInterface)
        {
            _IcedDrinksInterface = bebidasGeladasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> GetBebidasGeladas()
        {
            return Ok(await _IcedDrinksInterface.GetIcedDrinks());
        }

        [HttpGet("ByIcedId/{drinkId}")]
        public async Task<ActionResult<ServiceResponse<IcedDrinksModel>>> GetIcedDrinkById(int drinkId)
        {
            return Ok(await _IcedDrinksInterface.GetIcedDrinksById(drinkId));
        }

        [HttpGet("IngredientBy/{ingredinetDrinkId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsIcedDrinksModel>>>> GetIngredientsByIcedDrinks(int ingredinetDrinkId)
        {
            return Ok(await _IcedDrinksInterface.GetIngredientsByIcedDrinks(ingredinetDrinkId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> CreateIcedDrinks(DtoCreateIcedDrinks newIcedDrink)
        {
            return Ok(await _IcedDrinksInterface.CreateIcedDrinks(newIcedDrink));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> CreateIngredient(int id, DtoCreateIngredients newIngredient)
        {
            return Ok(await _IcedDrinksInterface.CreateIngredients(newIngredient, id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> UpdateIcedDrinks(IcedDrinksModel icedDrink)
        {
            return Ok(await _IcedDrinksInterface.UpdateIcedDrinks(icedDrink));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> DeleteIcedDrinks(int id)
        {
            return Ok(await _IcedDrinksInterface.DeleteBebidasGeladas(id));
        }

        [HttpDelete("DeleteIngredient/{id}")]
        public async Task<ActionResult<ServiceResponse<IngredientsIcedDrinksModel>>> DeleteIngredient(int id)
        {
            return Ok(await _IcedDrinksInterface.DeleteIngredient(id));
        }
    }
}