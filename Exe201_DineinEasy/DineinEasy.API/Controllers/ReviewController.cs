using AutoMapper;
using DineinEasy.API.RequestDTO.Review;
using DineinEasy.API.RequestDTO.TimeFrame;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class ReviewController : Controller
    {
        private IMapper _mapper;
        private IReviewService _reviewService;
        public ReviewController(IMapper mapper, IReviewService reviewService)
        {
            _mapper = mapper;
            _reviewService = reviewService;
        }
        [HttpGet("review/restaurants/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetReviewsbyRestaurantId([FromRoute] int id)
        {
            try
            {
                var list = await _reviewService.GetReviewsByRestaurantId(id);
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("review")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedReview dto)
        {
            try
            {
                var obj = _mapper.Map<ReviewModel>(dto);
                var result = await _reviewService.CreateReview(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("review/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedReview dto, [FromRoute] int id)
        {
            try
            {
                var obj = _mapper.Map<ReviewModel>(dto);
                var result = await _reviewService.UpdateReview(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("review/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _reviewService.GetReview(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("review/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _reviewService.DeleteReview(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("partner/review/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetForPartner([FromRoute] int id)
        {
            try
            {
                var result = await _reviewService.GetReviewsForPartner(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
