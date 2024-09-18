using AutoMapper;
using DineinEasy.API.RequestDTO.Area;
using DineinEasy.API.RequestDTO.Category;
using DineinEasy.API.RequestDTO.Package;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public ICategoryService _categoryService { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("categories")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _categoryService.GetAllCategory();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("category")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedCategory dto)
        {
            try
            {
                var obj = new CategoryModel {Name=dto.Name,Description= dto.Description};
                var result = await _categoryService.CreateCategory(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("category/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedCategory dto, [FromRoute] int id)
        {
            try
            {
                var obj = new CategoryModel { Name = dto.Name, Description = dto.Description,Status=dto.Status };
                var result = await _categoryService.UpdateCategory(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("category/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _categoryService.GetCategoryById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("category/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategorybyId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
