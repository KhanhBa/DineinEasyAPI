using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

namespace DineinEasy.Service.Services
{   
    public interface IOrderBookingService
    {
        Task<IBusinessResult> GetAllOrderBooking();
/*        Task<IBusinessResult> CreateOrderBooking(OrderBookingModel areaModel);
        Task<IBusinessResult> UpdateOrderBooking(int Id, OrderBookingModel areaModel);*/
        Task<IBusinessResult> GetOrderBookingById(int id);
        Task<IBusinessResult> GetPartnerOrderBookingById(int id);
        /*     Task<IBusinessResult> DeleteOrderBookingbyId(int id);*/
        Task<IBusinessResult> GetDashBoardForAdmin();
        Task<IBusinessResult> GetDashBoardForPartner(int restaurantId);
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

        public async Task<IBusinessResult> GetDashBoardForAdmin()
        {
            var obj = await _unitOfWork.OrderBookingRepository.GetNewOrderBookings();
            return new BusinessResult(200, "Get Dashboard Admin Successfully", obj);
        }

        public async Task<IBusinessResult> GetDashBoardForPartner(int restaurantId)
        {
            var obj = await _unitOfWork.OrderBookingRepository.GetNewOrderBookingsbyRestaurantId(restaurantId);
            return new BusinessResult(200, "Get Dashboard Partner Successfully", obj);
        }

        public async Task<IBusinessResult> GetOrderBookingById(int id)
        {
            var area = await _unitOfWork.OrderBookingRepository.GetByIdAsync(id);
            if (area == null)
            { return new BusinessResult(404, "Can not find OrderBooking"); }
            var result = _mapper.Map<OrderBookingModel>(area);
            return new BusinessResult(200, "Get order booking by Id successfully", result);
        }

        public async Task<IBusinessResult> GetPartnerOrderBookingById(int id)
        {
            List<OrderBooking> list = await _unitOfWork.OrderBookingRepository.GetOrderBookingsByRestaurantId(id);
            var result = _mapper.Map<List<OrderPartner>>(list);
            return new BusinessResult(200, "Get order booking by restaurantId successfully", result);
        }
    }
}
