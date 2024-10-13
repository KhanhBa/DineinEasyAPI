using AutoMapper;
using DineinEasy.API.RequestDTO.Customer;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMapper _mapper;
        private ICustomerService _customerService;
        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }
        [HttpGet("customers")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _customerService.GetAllCustomers();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("customers")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedCustomer dto)
        {
            try
            {
                var obj = _mapper.Map<CustomerModel>(dto);
                var result = await _customerService.CreateCustomer(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("customers/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedCustomer dto, [FromRoute] Guid id)
        {
            try
            {
                var obj = _mapper.Map<CustomerModel>(dto);
                var result = await _customerService.UpdateCustomer(obj, id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("customers/{id}/status/{status}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromRoute] int status, [FromRoute] Guid id)
        {
            try
            {
                var result = await _customerService.ChangeStatus(status, id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }




        [HttpGet("customers/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] Guid id)
        {
            try
            {
                var result = await _customerService.GetCustomerById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("customers/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] Guid id)
        {
            try
            {
                var result = await _customerService.DeleteCustomer(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("customers/{email}/{password}")]
        public async Task<ActionResult<IBusinessResult>> SignIn([FromRoute] string email, [FromRoute] string password)
        {
            try
            {
                var result = await _customerService.SignIn(email, password);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("customers/dashboard")]
        public async Task<ActionResult<IBusinessResult>> GetDashboardCustomer()
        {
            try
            {
                var result = await _customerService.DashboardCustomer();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
