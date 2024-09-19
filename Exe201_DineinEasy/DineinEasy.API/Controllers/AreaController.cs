using AutoMapper;
using DineinEasy.API.RequestDTO.Area;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class AreaController : Controller
    {
        public IAreaService _areaService { get; set; }
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [HttpGet("areas")]
        public async Task<ActionResult<IBusinessResult>> GetAllArea()
        {
            try
            {
                var list = await _areaService.GetAllArea();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("area")]
        public async Task<ActionResult<IBusinessResult>> CreateArea([FromBody] CreatedAreaDto areaDto)
        {
            try
            {
                var area = new AreaModel { City = areaDto.City, District = areaDto.District, Ward = areaDto.Ward };
                var result = await _areaService.CreateArea(area);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("area/{id}")]
        public async Task<ActionResult<IBusinessResult>> UpdateArea([FromBody] UpdatedAreaDto areaDto, [FromRoute] int id)
        {
            try
            {
                var area = new AreaModel { City = areaDto.City, District = areaDto.District, Ward = areaDto.Ward, Status = areaDto.Status };
                var result = await _areaService.UpdateArea(id,area);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("area/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetAreaByid([FromRoute] int id)
        {
            try
            {
                var result = await _areaService.GetAreaById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("area/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteAreaByid([FromRoute] int id)
        {
            try
            {
                var result = await _areaService.DeleteAreabyId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
