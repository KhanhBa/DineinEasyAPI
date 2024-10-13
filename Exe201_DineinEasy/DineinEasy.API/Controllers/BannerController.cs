using DineinEasy.API.RequestDTO.Area;
using DineinEasy.API.RequestDTO.Banner;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class BannerController : Controller
    {
        public IBannerService _bannerService { get; set; }
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        [HttpGet("banners")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _bannerService.GetAllBanner();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("banner")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedBanner Dto)
        {
            try
            {
                var obj = new BannerModel {ImageUrl = Dto.ImageUrl,RestaurantId=Dto.RestaurantId};
                var result = await _bannerService.CreateBanner(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("banner/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedBanner Dto, [FromRoute] int id)
        {
            try
            {
                var obj = new BannerModel {ImageUrl = Dto.ImageUrl,Status=Dto.Status, RestaurantId = Dto.RestaurantId };
                var result = await _bannerService.UpdateBanner(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("banner/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _bannerService.GetBannerById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("banner/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _bannerService.DeleteBannerbyId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
