using AutoMapper;
using DineinEasy.API.RequestDTO.User;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private IUserService _userService;
        public UserController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        [HttpGet("users")]
        public async Task<ActionResult<IBusinessResult>> GetAll()
        {
            try
            {
                var list = await _userService.GetAllUser();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("users")]
        public async Task<ActionResult<IBusinessResult>> Create([FromBody] CreatedUser dto)
        {
            try
            {
                var obj = _mapper.Map<UserModel>(dto);
                var result = await _userService.CreateUser(obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("users/{id}")]
        public async Task<ActionResult<IBusinessResult>> Update([FromBody] UpdatedUser dto, [FromRoute] int id)
        {
            try
            {
                var obj = _mapper.Map<UserModel>(dto);
                var result = await _userService.UpdateUser(id, obj);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("users/{id}")]
        public async Task<ActionResult<IBusinessResult>> GetByid([FromRoute] int id)
        {
            try
            {
                var result = await _userService.GetUserById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("users/{id}")]
        public async Task<ActionResult<IBusinessResult>> DeleteByid([FromRoute] int id)
        {
            try
            {
                var result = await _userService.DeleteUserbyId(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("users/{email}/{password}")]
        public async Task<ActionResult<IBusinessResult>> SignIn([FromRoute] string email, [FromRoute] string password)
        {
            try
            {
                var result = await _userService.SignIn(email, password);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
