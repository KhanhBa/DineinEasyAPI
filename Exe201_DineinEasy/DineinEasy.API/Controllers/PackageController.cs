using AutoMapper;
using DineinEasy.API.RequestDTO.Category;
using DineinEasy.API.RequestDTO.Package;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class PackageController : Controller
    {
        public IPackageService _packageService { get; set; }
        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("packages")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _packageService.GetAllPackage();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("package")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedPackage dto)
        {
            try
            {
                var obj = new PackageModel { Name = dto.Name, Description = dto.Description,Discount = dto.Discount,ValidDays=dto.ValidDays,ImageUrl= dto.ImageUrl,Price=dto.Price};
                var result = await _packageService.CreatePackage(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("package/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedPackage dto, [FromRoute] int id)
        {
            try
            {
                var obj = new PackageModel { Name = dto.Name, Description = dto.Description, Status = dto.Status, Discount = dto.Discount, ValidDays = dto.ValidDays, ImageUrl = dto.ImageUrl, Price = dto.Price};
                var result = await _packageService.UpdatePackagey(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("package/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _packageService.GetPackageById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("package/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _packageService.DeletePackagebyId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
