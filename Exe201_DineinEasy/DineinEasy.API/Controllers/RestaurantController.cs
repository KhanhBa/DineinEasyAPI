﻿using AutoMapper;
using DineinEasy.API.RequestDTO.Package;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class RestaurantController : Controller
    {
        private IMapper _mapper;
        private IRestaurantService _restaurantService;
        public RestaurantController(IMapper mapper,IRestaurantService restaurantService)
        {
            _mapper = mapper;
            _restaurantService = restaurantService;
        }
        [HttpGet("restaurants")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _restaurantService.GetAllRestaurants();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("restaurant")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedRestaurant dto)
        {
            try
            {
                var obj = _mapper.Map<RestaurantModel>(dto);
                var result = await _restaurantService.CreateRestaurant(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("restaurant/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedRestaurant dto, [FromRoute] int id)
        {
            try
            {
                var obj = _mapper.Map<RestaurantModel>(dto);
                var result = await _restaurantService.UpdateRestaurant(obj,id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("restaurant/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetRestaurantById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("restaurant/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.DeleteRestaurant(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
