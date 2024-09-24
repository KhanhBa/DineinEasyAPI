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
    public interface ITimeFrameService
    {
        Task<IBusinessResult> GetTimeFrameById(int id);
        Task<IBusinessResult> GetAllTimeFrames();
        Task<IBusinessResult> CreateTimeFrame(TimeFrameModel timeFrame);
        Task<IBusinessResult> UpdateTimeFrame(int Id,TimeFrameModel timeFrame);
        Task<IBusinessResult> DeleteTimeFrame(int id);
        Task<IBusinessResult> GetTimeFramesByRestaurantId(int restaurantId);
    }
    public class TimeFrameService: ITimeFrameService
    {
        private UnitOfWork _unitOfWork;
        private IMapper _mapper;
        public TimeFrameService(IMapper mapper)
        {
            _unitOfWork ??= new UnitOfWork();
            _mapper = mapper;
        }

        public async Task<IBusinessResult> CreateTimeFrame(TimeFrameModel timeFrame)
        {
            var obj = _mapper.Map<TimeFrame>(timeFrame);
            var created = await _unitOfWork.TimeFrameRepository.CreateAsync(obj);
            var result = _mapper.Map<TimeFrameModel>(created);
            return new BusinessResult(200, "Create successfully", result);       
        }

        public async Task<IBusinessResult> DeleteTimeFrame(int id)
        {
            var obj = await _unitOfWork.TimeFrameRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Restaurant"); }
            var check = await _unitOfWork.TimeFrameRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Deleted successfully");
        }

        public async Task<IBusinessResult> GetAllTimeFrames()
        {
            var list = await _unitOfWork.TimeFrameRepository.GetAllAsync();
            var result = _mapper.Map<List<TimeFrameModel>>(list);
            return new BusinessResult(200, "Get All TimeFrames");
        }

        public async Task<IBusinessResult> GetTimeFrameById(int id)
        {
            var list = await _unitOfWork.TimeFrameRepository.GetByIdAsync(id);
            var result = _mapper.Map<TimeFrameModel>(list);
            return new BusinessResult(200, "Get TimeFrame by Id");
        }

        public async Task<IBusinessResult> GetTimeFramesByRestaurantId(int restaurantId)
        {
            var list = await _unitOfWork.TimeFrameRepository.GetTimeFramesByRestaurantId(restaurantId);
            var result = _mapper.Map<List<TimeFrameModel>>(list);
            return new BusinessResult(200, "Get TimeFrames by RestaurantId");
        }

        public async Task<IBusinessResult> UpdateTimeFrame(int Id, TimeFrameModel timeFrame)
        {
            var obj = await _unitOfWork.TimeFrameRepository.GetByIdAsync(Id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Restaurant"); }
            timeFrame.RestaurantId = obj.RestaurantId;
            _mapper.Map(timeFrame, obj);
            var result = await _unitOfWork.TimeFrameRepository.UpdateAsync(obj);
            return new BusinessResult(200,"Updated successfully",result);
        }
    }
}
