using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.BebidasGeladasService;
using Microsoft.AspNetCore.Http;
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
            return Ok( await _IcedDrinksInterface.GetIcedDrinks());
        }

        [HttpGet("{drinkId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsIcedDrinksModel>>>> GetIngredientesByBebidasGeladas(int drinkId)
        {
            return Ok(await _IcedDrinksInterface.GetIngredientsByIcedDrinks(drinkId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> CreateIcedDrinks(DtoCreateIcedDrinks newIcedDrink)
        {
            return Ok(await _IcedDrinksInterface.CreateIcedDrinks(newIcedDrink));
        }
    }
}
