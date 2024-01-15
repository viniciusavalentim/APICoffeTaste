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
        private readonly MetodosService _metodosService;

        public MetodosController(MetodosService metodosService)
        {
            _metodosService = metodosService;
        }

        [HttpGet]
        public async Task<ActionResult<MetodosModel>> GetMetodos() //ActionResult - é igual ao ok ou badrequest
        {
            return Ok(await _metodosService.GetMetodos());
        }
    }
}
