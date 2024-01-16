using APICoffeTaste.Models;
using APICoffeTaste.Service.MetodosService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodosController : ControllerBase
    {
        private readonly IMetodosInterface _metodosInterface; //quando eu for buscar os metodos, eu vou buscar da minha interface e nao do service(na controller)
        public MetodosController(IMetodosInterface metodos)
        {
            _metodosInterface = metodos;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<MetodosModel>>>> GetMetodos()
        {
            return Ok(await _metodosInterface.GetMetodos());
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ServiceResponse<MetodosModel>>> GetMetodosById(int id)
        {
            return Ok(await _metodosInterface.GetMetodoById(id));
        }

        [HttpGet("ByVariacao/{variacao}")]
        public async Task<ActionResult<List<MetodosModel>>> GetMetodosByVaiacao(string variacao)
        {
            return Ok(await _metodosInterface.GetMetodosByVariacao(variacao));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MetodosModel>>>> CreateMetodos(MetodosModel novoMetodo)
        {
            return Ok(await _metodosInterface.CreateMetodos(novoMetodo));
        }


    }
}
