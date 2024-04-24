using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.CoffeeSprintsService;
using APICoffeeTaste.Service.TeasService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeSprintsController : ControllerBase
    {

        private readonly ICoffeeSprintsInterface _coffeeSprintInterface;
        public CoffeeSprintsController(ICoffeeSprintsInterface coffeeSprintsInterface)
        {
            _coffeeSprintInterface = coffeeSprintsInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CoffeeSprintsModel>>>> GetCoffeeSprints()
        {
            return Ok(await _coffeeSprintInterface.GetCoffeeSprints());
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ServiceResponse<CoffeeSprintsModel>>> GetCoffeeSprintsById(int id)
        {
            return Ok(await _coffeeSprintInterface.GetCoffeeSprintsById(id));
        }

        [HttpGet("IngredientBy/{id}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsCoffeeSprintsModel>>>> GetIngredientsByCoffeeSprints(int id)
        {
            return Ok(await _coffeeSprintInterface.GetIngredientsByCoffeeSprintId(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CoffeeSprintsModel>>>> CreateCoffeeSprints(DtoCreateCoffeeSprints newCoffeeSprints)
        {
            return Ok(await _coffeeSprintInterface.CreateCoffeeSprints(newCoffeeSprints));
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> CreateTea(int id, DtoCreateIngredients newIngredient)
        {
            return Ok(await _coffeeSprintInterface.CreateIngredients(newIngredient, id));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<CoffeeSprintsModel>>>> UpdateCoffeeSprints(CoffeeSprintsModel coffeeSprints)
        {
            return Ok(await _coffeeSprintInterface.UpdateCoffeeSprints(coffeeSprints));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<CoffeeSprintsModel>>>> DeleteCoffeeSprints(int id)
        {
            return Ok(await _coffeeSprintInterface.DeleteCoffeeSprints(id));
        }

    }
}
