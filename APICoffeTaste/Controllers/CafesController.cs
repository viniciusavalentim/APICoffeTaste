using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.CafeService;
using APICoffeeTaste.Service.MetodosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafesController : ControllerBase
    {
        private readonly ICafesInterface _cafesInterface; //quando eu for buscar os metodos, eu vou buscar da minha interface e nao do service(na controller)
        public CafesController(ICafesInterface cafes)
        {
            _cafesInterface = cafes;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CafesModel>>>> GetCafes()
        {
            return Ok(await _cafesInterface.GetCafes());
        }

        [HttpGet("{metodoId}")]
        public async Task<ActionResult<ServiceResponse<List<CafesModel>>>> GetCafesByMetodo(int metodoId)
        {
            return Ok(await _cafesInterface.GetCafesByMetodo(metodoId));
        }
        [HttpPost("{metodoId}")]
        public async Task<ActionResult<ServiceResponse<List<CafesModel>>>> CreateMetodos(int metodoId, DtoCreateCafe novoCafe)
        {
            ServiceResponse<List<CafesModel>> create = await _cafesInterface.CreateCafes(novoCafe, metodoId);
            return Ok(create);
        }
    }
}
