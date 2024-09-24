using AutoMapper;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.API.RequestDTO.TimeFrame;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    public class TimeFrameController : Controller
    {
        private IMapper _mapper;
        private ITimeFrameService _timeFrameService;
        public TimeFrameController(IMapper mapper, ITimeFrameService timeFrameService)
        {
            _mapper = mapper;
            _timeFrameService = timeFrameService;
        }
        [HttpGet("timeframes")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _timeFrameService.GetAllTimeFrames();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("timeframe")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedTimeFrame dto)
        {
            try
            {
                var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.OpenedTime, ClosedTime = dto.ClosedTime,RestaurantId=dto.RestaurantId };
                var result = await _timeFrameService.CreateTimeFrame(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("timeframe/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedTimeFrame dto, [FromRoute] int id)
        {
            try
            {
                var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.OpenedTime, ClosedTime = dto.ClosedTime };
                var result = await _timeFrameService.UpdateTimeFrame(id,obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("timeframe/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _timeFrameService.GetTimeFrameById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("timeframe/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _timeFrameService.DeleteTimeFrame(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("timeframe/restaurant/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByRestaurantId([FromRoute] int id)
        {
            try
            {
                var result = await _timeFrameService.GetTimeFramesByRestaurantId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
