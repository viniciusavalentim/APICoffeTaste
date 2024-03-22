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
        private readonly IBebidasGeladasInterface _bebidasGeladasInterface;
        public BebidasGeladasController(IBebidasGeladasInterface bebidasGeladasInterface)
        {
            _bebidasGeladasInterface = bebidasGeladasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<BebidasGeladasModel>>>> GetBebidasGeladas()
        {
            return Ok( await _bebidasGeladasInterface.GetBebidasGeladas());
        }

        [HttpGet("{bebidaId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientesModel>>>> GetIngredientesByBebidasGeladas(int bebidaId)
        {
            return Ok(await _bebidasGeladasInterface.GetIngredienteByBebidasGeladas(bebidaId));
        }
    }
}
