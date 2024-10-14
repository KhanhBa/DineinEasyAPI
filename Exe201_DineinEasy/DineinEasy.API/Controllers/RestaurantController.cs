using AutoMapper;
using DineinEasy.API.RequestDTO.Package;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

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
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("restaurants")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedRestaurant dto)
        {
            try
            {
                var obj = _mapper.Map<RestaurantModel>(dto);
                var result = await _restaurantService.CreateRestaurant(obj);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("restaurants/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedRestaurant dto, [FromRoute] int id)
        {
            try
            {
                var obj = _mapper.Map<RestaurantModel>(dto);
                var result = await _restaurantService.UpdateRestaurant(obj,id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok( ex.Message);
            }
        }
        [HttpGet("restaurants/{id}")]
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
        [HttpDelete("restaurants/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.DeleteRestaurant(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("restaurants/{email}/{password}")]
        public async Task<ActionResult<IBusinessResult>> SignIn([FromRoute] string email , [FromRoute] string password)
        {
            try
            {
                var result = await _restaurantService.SignIn(email,password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("restaurants/{id}/images")]
        public async Task<ActionResult<IBusinessResult>> GetImagesByRestaurantId([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetImageRestaurantById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("restaurants/{id}/reviews")]
        public async Task<ActionResult<IBusinessResult>> GetReviewsByRestaurantId([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetReviewsRestaurantById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("restaurants/{id}/banners")]
        public async Task<ActionResult<IBusinessResult>> GetBannersByRestaurantId([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetBannersByRestaurantId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("restaurants/{id}/status/{status}")]
        public async Task<ActionResult<IBusinessResult>> ChangeStatus([FromRoute] int id, [FromRoute] int status)
        {
            try
            {
                var result = await _restaurantService.ChangeStatus(id,status);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("partner/restaurants/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetForPartnerByid([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetInfomationForPartner(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("partner/restaurants/{id}/images")]
        public async Task<ActionResult<IBusinessResult>> GetImages([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetImageRestaurantById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
            [HttpPost("restaurants/{id}/partners/images/")]
            public async Task<ActionResult<IBusinessResult>> Create([FromBody] List<RestaurantImageModel> dto, [FromRoute] int id)
            {
                try
                {
                    var result = await _restaurantService.ChangeImageRestaurant(id,dto);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        [HttpPut("restaurants/{id}/partners")]
        public async Task<ActionResult<IBusinessResult>> UpdatePartner([FromBody] RestaurantUpdatePartner dto, [FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.UpdateRestaurantPartner(dto, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
        [HttpGet("restaurants/{id}/booking-orders")]
        public async Task<ActionResult<IBusinessResult>> GetBookingOrdersByRestaurantId([FromRoute] int id)
        {
            try
            {
                var result = await _restaurantService.GetBookingOrdersByRestaurantId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    }
