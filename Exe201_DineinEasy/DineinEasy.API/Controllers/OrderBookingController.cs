using DineinEasy.Service.Responses;
using DineinEasy.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineinEasy.API.Controllers
{
    [Route("orders-booking")]
    [ApiController]
    public class OrderBookingController : ControllerBase
    {
        public IOrderBookingService _orderBookingService { get; set; }
        public OrderBookingController(IOrderBookingService orderBookingService)
        {
            _orderBookingService = orderBookingService;
        }
        [HttpGet()]
        public async Task<ActionResult<IBusinessResult>> GetAllOrderBooking()
        {
            try
            {
                var list = await _orderBookingService.GetAllOrderBooking();
                return StatusCode(list.Status, list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IBusinessResult>> GetOrderBookingByid([FromRoute] int id)
        {
            try
            {
                var result = await _orderBookingService.GetOrderBookingById(id);
                return StatusCode(result.Status, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
