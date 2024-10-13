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
    public interface IRestaurantPackageService
    {
        Task<IBusinessResult> GetAll();
        Task<IBusinessResult> Create( OrderMembershipModel orderMembershipModel);
        Task<IBusinessResult> Update(int id, OrderMembershipModel orderMembershipModel);
        Task<IBusinessResult> Delete(int packageModelid);
        Task<IBusinessResult> GetById(int id);
        Task<IBusinessResult> Dashboard();
    }
    public class RestaurantPackageService : IRestaurantPackageService
   {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public RestaurantPackageService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<IBusinessResult> Create(OrderMembershipModel packageModel)
        {
            var obj = _mapper.Map<OrderMembership>(packageModel);
            obj.Status = true;
            var package = await _unitOfWork.PackageRepository.GetByIdAsync(packageModel.PackageId);
            if (package == null) { throw new Exception("Can not find package"); }
            var restaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(packageModel.RestaurantId);
            if (restaurant == null) { throw new Exception("Can not find restaurant"); }
            obj.Name = package.Name;
            obj.Description = package.Description;
            obj.CreatedDate = DateTime.Now;
            obj.ValueDays = package.ValueDays;
            obj.ImageUrl = package.ImageUrl;
            obj.Price = package.Price;
            obj.Discount = package.Discount;
            obj.ExpiredDate = DateTime.Now.AddDays(package.ValueDays);
            var created = await _unitOfWork.OrderMembershipRepository.CreateAsync(obj);
            var result = _mapper.Map<OrderMembershipModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public Task<IBusinessResult> Dashboard()
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> Delete(int packageModelid)
        {
            var list = await _unitOfWork.PackagerRestaurantRepository.GetByIdAsync(packageModelid);
            if (list == null) { throw new Exception("Can not find the order membership"); }
            var result = await _unitOfWork.OrderMembershipRepository.RemoveAsync(list);
            return new BusinessResult(200, "Removed Restaurant Package",result);
        }

        public async Task<IBusinessResult> GetAll()
        {
            var list = await _unitOfWork.PackagerRestaurantRepository.GetAllAsync();
            var data = _mapper.Map<List<OrderMembership>>(list);
            var result = new BusinessResult(200, "Get All Restaurant Package", data);
            return result;
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var list = await _unitOfWork.PackagerRestaurantRepository.GetByIdAsync(id);
            var data = _mapper.Map<OrderMembership>(list);
            var result = new BusinessResult(200, "Get Restaurant Package", data);
            return result;
        }

        public async Task<IBusinessResult> Update(int id, OrderMembershipModel model)
        {
            var list = await _unitOfWork.PackagerRestaurantRepository.GetByIdAsync(id);
            if (list == null) { throw new Exception("Can not find the order membership"); }
            model.CreatedDate = DateTime.Now;
            model.RestaurantId = list.RestaurantId;
            model.PackageId = list.PackageId;
            _mapper.Map(model, list);
            var result = _unitOfWork.OrderMembershipRepository.UpdateAsync(list);
            return new BusinessResult(200, "Updated Restaurant Package", result);
        }
    }
}
