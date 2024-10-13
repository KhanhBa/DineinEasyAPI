using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DineinEasy.Data.Models;
using DineinEasy.Service.Services;
using DineinEasy.Service.Responses;
using DineinEasy.API.RequestDTO.OrderMember;
using DineinEasy.Service.Models;

namespace DineinEasy.API.Controllers
{
    [Route("orders-packages")]
    [ApiController]
    public class OrderMembershipsController : Controller
    {
        private IRestaurantPackageService _context { get; set; }
        public OrderMembershipsController(IRestaurantPackageService context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _context.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IBusinessResult>> GetById([FromRoute] int id)
        {
            try
            {
                var list = await _context.GetById(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedOrderMembership model)
        {
            try
            {
                var obj = new OrderMembershipModel();
                obj.RestaurantId = model.RestaurantId;
                obj.PackageId = model.PackageId;
                var list = await _context.Create(obj);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<IBusinessResult>> RemoveById([FromRoute] int id)
        {
            try
            {
                var list = await _context.Delete(id);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedOrderMembership model, [FromRoute]int id)
        {
            try
            {
                var obj = new OrderMembershipModel();
                obj.ValidDays = model.ValidDays;
                obj.ExpiredDate = model.ExpiredDate;
                obj.Name = model.Name;
                obj.Description = model.Description;
                obj.Price = model.Price;
                obj.Discount = model.Discount;
                obj.ImageUrl = model.ImageUrl;
                obj.Status = model.Status;
                var list = await _context.Update(id,obj);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
