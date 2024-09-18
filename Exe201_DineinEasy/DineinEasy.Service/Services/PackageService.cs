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
    public interface IPackageService
    {
        Task<IBusinessResult> GetAllPackage();
        Task<IBusinessResult> CreatePackage(PackageModel model);
        Task<IBusinessResult> UpdatePackagey(int Id, PackageModel model);
        Task<IBusinessResult> GetPackageById(int id);
        Task<IBusinessResult> DeletePackagebyId(int id);
    }
    public class PackageService : IPackageService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PackageService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<IBusinessResult> CreatePackage(PackageModel model)
        {
            var obj = _mapper.Map<Package>(model);
            obj.Status = true;
            obj.CreateAt = DateTime.Now;
            var created = await _unitOfWork.PackageRepository.CreateAsync(obj);
            var result = _mapper.Map<PackageModel>(created);
            return new BusinessResult(200, "Create successfully", result);
        }

        public async Task<IBusinessResult> DeletePackagebyId(int id)
        {
            var obj = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Package"); }
            var result = await _unitOfWork.PackageRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Delete Package by Id successfully", result);
        }

        public async Task<IBusinessResult> GetAllPackage()
        {
            var list = await _unitOfWork.PackageRepository.GetAllAsync();
            var data = _mapper.Map<List<PackageModel>>(list);
            var result = new BusinessResult(200, "Get All Package", data);
            return result;
        }

        public async Task<IBusinessResult> GetPackageById(int id)
        {
            var obj = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Package"); }
            var result = _mapper.Map<PackageModel>(obj);
            return new BusinessResult(200, "Get Package by Id successfully", result);
        }
        public async Task<IBusinessResult> UpdatePackagey(int Id, PackageModel model)
        {
            var obj = await _unitOfWork.PackageRepository.GetByIdAsync(Id);
            if (obj == null) { return new BusinessResult(404, "Can not find Package"); }
            model.CreateAt = obj.CreateAt;  
            _mapper.Map(model, obj);
            var updated = await _unitOfWork.PackageRepository.UpdateAsync(obj);
            var result = _mapper.Map<PackageModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }
    }
}