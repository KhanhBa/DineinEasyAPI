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
    public interface IAreaService
    {
        Task<IBusinessResult> GetAllArea();
        Task<IBusinessResult> CreateArea(AreaModel areaModel);
        Task<IBusinessResult> UpdateArea(int Id,AreaModel areaModel);
        Task<IBusinessResult> GetAreaById(int id);
        Task<IBusinessResult> DeleteAreabyId(int id);
    }
    public class AreaService:IAreaService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AreaService(IMapper mapper) {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }
        public async Task<IBusinessResult> GetAllArea()
        {
            var list = await _unitOfWork.AreaRepository.GetAllAsync();
            var data = _mapper.Map<List<AreaModel>>(list);
            var result = new BusinessResult(200,"Get All Area",data);
            return result;
        }
        public async Task<IBusinessResult> CreateArea(AreaModel areaModel)
        {
            var area = _mapper.Map<Area>(areaModel);
            area.Status = true;
            var created = await _unitOfWork.AreaRepository.CreateAsync(area);
            var result = _mapper.Map<AreaModel>(created);
            return new BusinessResult(200,"Create successfully",result);
        }
        public async Task<IBusinessResult> UpdateArea(int Id, AreaModel areaModel)
        {
            var area = await _unitOfWork.AreaRepository.GetByIdAsync(Id);
            if (area == null) {return new BusinessResult(404, "Can not find Area");}
            _mapper.Map(areaModel, area);
            var updated = await _unitOfWork.AreaRepository.UpdateAsync(area);
            var result = _mapper.Map<AreaModel>(area);
            return new BusinessResult(200, "Update successfully", result);
        }

        public async Task<IBusinessResult> GetAreaById(int id)
        {
            var area = await _unitOfWork.AreaRepository.GetByIdAsync(id);
            if (area == null)
            { return new BusinessResult(404, "Can not find Area");}
            var result = _mapper.Map<AreaModel>(area);
            return new BusinessResult(200, "Get area by Id successfully", result);
            }

        public async Task<IBusinessResult> DeleteAreabyId(int id)
        {
            var area = await _unitOfWork.AreaRepository.GetByIdAsync(id);
            if (area == null)
            { return new BusinessResult(404, "Can not find Area"); }
            var result = await _unitOfWork.AreaRepository.RemoveAsync(area);
            return new BusinessResult(200, "Delete area by Id successfully", result);
        }
    }
}
