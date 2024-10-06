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
    public interface IBannerService
    {
        Task<IBusinessResult> GetAllBanner();
        Task<IBusinessResult> CreateBanner(BannerModel model);
        Task<IBusinessResult> UpdateBanner(int Id, BannerModel model);
        Task<IBusinessResult> GetBannerById(int id);
        Task<IBusinessResult> DeleteBannerbyId(int id);
    }
    public class BannerService:IBannerService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BannerService( IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper= mapper;
        }

        public async Task<IBusinessResult> CreateBanner(BannerModel model)
        {
            var obj = _mapper.Map<Banner>(model);
            obj.Status = true;
            obj.CreatedAt = DateTime.Now;
            obj.ExpriedDate = DateTime.Now.AddDays(7);
            var created = await _unitOfWork.BannerRepository.CreateAsync(obj);
            var result = _mapper.Map<BannerModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public async Task<IBusinessResult> DeleteBannerbyId(int id)
        {
            var obj = await _unitOfWork.BannerRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Banner"); }
            var result = await _unitOfWork.BannerRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Delete Banner by Id successfully", result);
        }

        public async Task<IBusinessResult> GetAllBanner()
        {
            var list = await _unitOfWork.BannerRepository.GetAllAsync();
            var data = _mapper.Map<List<BannerModel>>(list);
            var result = new BusinessResult(200, "Get All Banner", data);
            return result;
        }

        public async Task<IBusinessResult> GetBannerById(int id)
        {
            var obj = await _unitOfWork.BannerRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Banner"); }
            var result = _mapper.Map<BannerModel>(obj);
            return new BusinessResult(200, "Get Banner by Id successfully", result);
        }
        public async Task<IBusinessResult> UpdateBanner(int Id, BannerModel model)
        {
            var obj = await _unitOfWork.BannerRepository.GetByIdAsync(Id);
            if (obj == null) { return new BusinessResult(404, "Can not find Banner"); }
            model.ExpriedDate = obj.ExpriedDate;
            model.CreatedAt = obj.CreatedAt;
            _mapper.Map(model, obj);
            var updated = await _unitOfWork.BannerRepository.UpdateAsync(obj);
            var result = _mapper.Map<BannerModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }
    }
}
