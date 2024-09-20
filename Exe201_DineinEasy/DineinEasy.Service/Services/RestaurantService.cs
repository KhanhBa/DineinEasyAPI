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

namespace DineinEasy.Service.Services
{
    public interface IRestaurantService
    {
        Task<IBusinessResult> CreateRestaurant(RestaurantModel model);
        Task<IBusinessResult> UpdateRestaurant(RestaurantModel restaurant,int id);
        Task<IBusinessResult> DeleteRestaurant(int id);
        Task<IBusinessResult> GetAllRestaurants();
        Task<IBusinessResult> GetRestaurantById(int id);
    }
    public class RestaurantService:IRestaurantService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public RestaurantService(IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> CreateRestaurant(RestaurantModel model)
        {
            var obj = _mapper.Map<Restaurant>(model);
            obj.Status = true;
            obj.CreateAt = DateTime.Now;
            obj.UpdateAt = DateTime.Now;
            var created = await _unitOfWork.RestaurantRepository.CreateAsync(obj);
            var result = _mapper.Map<RestaurantModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public async Task<IBusinessResult> DeleteRestaurant(int id)
        {
            var obj = await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Restaurant"); }
            var result = await _unitOfWork.RestaurantRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Delete Restaurant by Id successfully", result);
        }

        public async Task<IBusinessResult> GetAllRestaurants()
        {
            var list = await _unitOfWork.RestaurantRepository.GetAllAsync();
            var data = _mapper.Map<List<RestaurantModel>>(list);
            var result = new BusinessResult(200, "Get All Restaurant", data);
            return result;
        }

        public async Task<IBusinessResult> GetRestaurantById(int id)
        {
            var obj = await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Restaurant"); }
            var result = _mapper.Map<RestaurantModel>(obj);
            return new BusinessResult(200, "Get Restaurant by Id successfully", result);
        }

        public async Task<IBusinessResult> UpdateRestaurant(RestaurantModel restaurant, int id)
        {
            var obj = await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
            if (obj == null) { return new BusinessResult(404, "Can not find Restaurant"); }
            restaurant.UpdateAt = DateTime.Now;
            restaurant.CreateAt = obj.CreateAt;
            _mapper.Map(restaurant, obj);
            var updated = await _unitOfWork.RestaurantRepository.UpdateAsync(obj);
            var result = _mapper.Map<RestaurantModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }
    }
}
