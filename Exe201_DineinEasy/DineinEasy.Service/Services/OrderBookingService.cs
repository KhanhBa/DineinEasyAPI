using AutoMapper;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Services
{   
    public interface IOrderBookingService
    {
        Task<IBusinessResult> GetAllOrderBooking();
/*        Task<IBusinessResult> CreateOrderBooking(OrderBookingModel areaModel);
        Task<IBusinessResult> UpdateOrderBooking(int Id, OrderBookingModel areaModel);*/
        Task<IBusinessResult> GetOrderBookingById(int id);
   /*     Task<IBusinessResult> DeleteOrderBookingbyId(int id);*/
    }
    public class OrderBookingService : IOrderBookingService
    {
        private  UnitOfWork _unitOfWork;
        private IMapper _mapper;

        public OrderBookingService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<IBusinessResult> GetAllOrderBooking()
        {
            var list = await _unitOfWork.OrderBookingRepository.GetAllAsync();
            var data = _mapper.Map<List<OrderBookingModel>>(list);
            var result = new BusinessResult(200, "Get All Order Booking", data);
            return result;
        }

        public async Task<IBusinessResult> GetOrderBookingById(int id)
        {
            var area = await _unitOfWork.OrderBookingRepository.GetByIdAsync(id);
            if (area == null)
            { return new BusinessResult(404, "Can not find Area"); }
            var result = _mapper.Map<OrderBookingModel>(area);
            return new BusinessResult(200, "Get order booking by Id successfully", result);
        }
    }
}
