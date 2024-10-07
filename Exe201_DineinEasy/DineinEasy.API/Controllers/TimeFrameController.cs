using AutoMapper;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.API.RequestDTO.TimeFrame;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

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
        [HttpPost("timeframes")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedTimeFrame dto)
        {
            try
            {
                var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.GetOpenedTime(), ClosedTime = dto.GetClosedTime(), RestaurantId = dto.RestaurantId };
                var result = await _timeFrameService.CreateTimeFrame(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("timeframes/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedTimeFrame dto, [FromRoute] int id)
        {
            try
            {
                var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.GetOpenedTime(), ClosedTime = dto.GetClosedTime() };
                var result = await _timeFrameService.UpdateTimeFrame(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("timeframes/{id}")]
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
        [HttpDelete("timeframes/{id}")]
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
        [HttpGet("timeframes/restaurant/{id}")]
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
        [HttpPost("timeframes/partners/{id}")]
        public async Task<ActionResult<IBusinessResult>> ChangeTimeframeByPartner([FromBody] List<TimeFrameChange> list, [FromRoute] int id)
        {
            try
            {
                foreach (var dto in list)
                {
                    if (dto.Id == 0)
                    {
                    var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.GetOpenedTime(), ClosedTime = dto.GetClosedTime(), RestaurantId = id };
                    var rs = await _timeFrameService.CreateTimeFrame(obj);
                    }
                    else
                    {
                    var obj = new TimeFrameModel { Day = dto.Day, OpenedTime = dto.GetOpenedTime(), ClosedTime = dto.GetClosedTime() };
                    await _timeFrameService.UpdateTimeFrame(id, obj);
                    }
                }
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
