using APICoffeTaste.Dtos;
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


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<MetodosModel>>>> CreateMetodos(DtoCreateMetodo novoMetodo)
        {
            ServiceResponse<List<MetodosModel>> create = await _metodosInterface.CreateMetodos(novoMetodo);
            return Ok(create);
        }

        [HttpPut] //editar
        public async Task<ActionResult<ServiceResponse<List<MetodosModel>>>> UpdateMetodos(MetodosModel editarMetodo)
        {
            ServiceResponse<List<MetodosModel>> update = await _metodosInterface.UpdateMetodos(editarMetodo);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<MetodosModel>>>> DeleteMetodos(int id)
        {
            ServiceResponse<List<MetodosModel>> delete = await _metodosInterface.DeleteMetodos(id);
            return Ok(delete);
        }





    }
}
