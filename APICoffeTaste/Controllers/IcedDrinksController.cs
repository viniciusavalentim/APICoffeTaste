﻿using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.IcedDrinksService;
using Microsoft.AspNetCore.Mvc;

namespace APICoffeeTaste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IcedDrinksController : ControllerBase
    {
        private readonly IIcedDrinksInterface _IcedDrinksInterface;
        public IcedDrinksController(IIcedDrinksInterface bebidasGeladasInterface)
        {
            _IcedDrinksInterface = bebidasGeladasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> GetBebidasGeladas()
        {
            return Ok( await _IcedDrinksInterface.GetIcedDrinks());
        }

        [HttpGet("IngredientById")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsIcedDrinksModel>>>> GetIngredientsByIcedDrinks(int drinkId)
        {
            return Ok(await _IcedDrinksInterface.GetIngredientsByIcedDrinks(drinkId));
        }

        [HttpGet("ByIcedId/{id}")]
        public async Task<ActionResult<ServiceResponse<IcedDrinksModel>>> GetIcedDrinkById(int drinkId)
        {
            return Ok(await _IcedDrinksInterface.GetIcedDrinksById(drinkId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> CreateIcedDrinks(DtoCreateIcedDrinks newIcedDrink)
        {
            return Ok(await _IcedDrinksInterface.CreateIcedDrinks(newIcedDrink));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> UpdateIcedDrinks(IcedDrinksModel icedDrink)
        {
            return Ok(await _IcedDrinksInterface.UpdateIcedDrinks(icedDrink));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<IcedDrinksModel>>>> DeleteIcedDrinks(int id)
        {
            return Ok(await _IcedDrinksInterface.DeleteBebidasGeladas(id));
        }
    }
}
