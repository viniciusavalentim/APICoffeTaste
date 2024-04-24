using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.TeasService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeasController : ControllerBase
    {
        private readonly ITeasInterface _teasInterface;
        public TeasController(ITeasInterface teasInterface)
        {
            _teasInterface = teasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> GetTeas()
        {
            return Ok(await _teasInterface.GetTeas());
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ServiceResponse<TeasModel>>> GetTeaById(int id)
        {
            return Ok(await _teasInterface.GetTeaById(id));
        }

        [HttpGet("IngredientBy/{teaId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsTeasModel>>>> GetIngredientsByTea(int teaId)
        {
            return Ok(await _teasInterface.GetIngredientsByTea(teaId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> CreateTea(DtoCreateTeas newTea)
        {
            return Ok(await _teasInterface.CreateTeas(newTea));
        }

        [HttpPost("{teaId}")]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> CreateTea(int teaId, DtoCreateIngredients newIngredient)
        {
            return Ok(await _teasInterface.CreateIngredients(newIngredient, teaId));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> UpdateTea(TeasModel tea)
        {
            return Ok(await _teasInterface.UpdateTeas(tea));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TeasModel>>>> DeleteTea(int id)
        {
            return Ok(await _teasInterface.DeleteTea(id));
        }

    }
}
