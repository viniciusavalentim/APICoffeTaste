using APICoffeeTaste.Models;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.IcedDrinksService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotDrinksController : ControllerBase
    {
        private readonly IHotDrinksInterface _hotDrinksInterface;
        public HotDrinksController(IHotDrinksInterface icedDrinksInterface)
        {
            _hotDrinksInterface = icedDrinksInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> GetBebidasGeladas()
        {
            return Ok(await _hotDrinksInterface.GetHotDrinks());
        }
    }
}
