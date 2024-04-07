﻿using APICoffeeTaste.Dtos;
using APICoffeeTaste.Models;
using APICoffeeTaste.Service.HotDrinksService;
using APICoffeeTaste.Service.IcedDrinksService;
using APICoffeeTaste.Service.MetodosService;
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

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<ServiceResponse<HotDrinksModel>>> GetHotDrinksById(int id)
        {
            return Ok(await _hotDrinksInterface.GetHotDrinksById(id));
        }

        [HttpGet("IngredientBy/{ingredinetDrinkId}")]
        public async Task<ActionResult<ServiceResponse<List<IngredientsHotDrinksModel>>>> GetIngredientsByIcedDrinks(int ingredinetDrinkId)
        {
            return Ok(await _hotDrinksInterface.GetIngredientsByHotDrinks(ingredinetDrinkId));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<HotDrinksModel>>>> CreateIcedDrinks(DtoCreateHotDrinks newIcedDrink)
        {
            return Ok(await _hotDrinksInterface.CreateHotDrinks(newIcedDrink));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<HotDrinksModel>>>> UpdateIcedDrinks(HotDrinksModel icedDrink)
        {
            return Ok(await _hotDrinksInterface.UpdateHotDrinks(icedDrink));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<HotDrinksModel>>>> DeleteIcedDrinks(int id)
        {
            return Ok(await _hotDrinksInterface.DeleteHotDrinks(id));
        }
    }
}
