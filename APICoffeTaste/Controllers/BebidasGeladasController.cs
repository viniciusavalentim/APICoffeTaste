using APICoffeeTaste.Models;
using APICoffeeTaste.Service.BebidasGeladasService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BebidasGeladasController : ControllerBase
    {
        private readonly IIcedDrinksInterface _bebidasGeladasInterface;
        public BebidasGeladasController(IIcedDrinksInterface bebidasGeladasInterface)
        {
            _bebidasGeladasInterface = bebidasGeladasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> GetBebidasGeladas()
        {
            return Ok( await _bebidasGeladasInterface.GetIcedDrinks());
        }

        [HttpGet("{bebidaId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsModel>>>> GetIngredientesByBebidasGeladas(int bebidaId)
        {
            return Ok(await _bebidasGeladasInterface.GetIngredientsByIcedDrinks(bebidaId));
        }
    }
}
