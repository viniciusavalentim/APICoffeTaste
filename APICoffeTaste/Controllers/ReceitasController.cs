using APICoffeeTaste.Models;
using APICoffeeTaste.Service.CafeService;
using APICoffeeTaste.Service.MetodosService;
using APICoffeeTaste.Service.ReceitaService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly IReceitaInteface _receitasInterface; //quando eu for buscar os metodos, eu vou buscar da minha interface e nao do service(na controller)
        public ReceitasController(IReceitaInteface receitas)
        {
            _receitasInterface = receitas;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ReceitasModel>>>> GetReceita()
        {
            return Ok(await _receitasInterface.GetReceita());
        }

        [HttpGet("{cafeId}")]
        public async Task<ActionResult<ServiceResponse<List<CafesModel>>>> GetReceitaByCafe(int cafeId)
        {
            return Ok(await _receitasInterface.GetReceitaByCafe(cafeId));
        }
    }
}
