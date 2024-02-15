using APICoffeTaste.Dtos;
using APICoffeTaste.Models;
using APICoffeTaste.Service.CafeService;
using APICoffeTaste.Service.MetodosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeTaste.Controllers
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
        public async Task<ActionResult<ServiceResponse<List<CafesModel>>>> CreateMetodos(DtoCreateCafe novoCafe, int metodoId)
        {
            ServiceResponse<List<CafesModel>> create = await _cafesInterface.CreateCafes(novoCafe, metodoId);
            return Ok(create);
        }
    }
}
