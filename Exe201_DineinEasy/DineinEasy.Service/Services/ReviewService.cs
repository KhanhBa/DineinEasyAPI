using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Models.PartnerModels;
using DineinEasy.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

namespace DineinEasy.Service.Services
{
    public interface IReviewService
    {
        Task<IBusinessResult> GetReview(int id);
        Task<IBusinessResult> UpdateReview(int Id,ReviewModel moder);
        Task<IBusinessResult> DeleteReview(int Id);
        Task<IBusinessResult> CreateReview(ReviewModel moder);
        Task<IBusinessResult> GetReviewsByRestaurantId(int restaurantId);
        Task<IBusinessResult> GetReviewsForPartner(int restaurantId);
    }
    public class ReviewService : IReviewService
    {
        private IMapper _mapper;
        private UnitOfWork _unitOfWork;
        public ReviewService(IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork ??= new UnitOfWork();
        }

        public async Task<IBusinessResult> CreateReview(ReviewModel moder)
        {
           var obj = _mapper.Map<Review>(moder);
           var created = await _unitOfWork.ReviewRepository.CreateAsync(obj);
           var result = _mapper.Map<Review>(created);
           return new BusinessResult(200, "Created successfully",result);
        }

        public async Task<IBusinessResult> DeleteReview(int Id)
        {
           var obj = await _unitOfWork.ReviewRepository.GetByIdAsync(Id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Review");}
            var result = await _unitOfWork.ReviewRepository.RemoveAsync(obj);
            return new BusinessResult(200, "Deleted successfully");
        }

        public async Task<IBusinessResult> GetReview(int id)
        {
            var obj = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Review"); }
            var result = _mapper.Map<ReviewModel>(obj);
            return new BusinessResult(200,"Get Review by Id",result);
        }

        public async Task<IBusinessResult> GetReviewsByRestaurantId(int restaurantId)
        {
            var obj = await _unitOfWork.ReviewRepository.GetReviewsByRestaurantIdAsync(restaurantId);
            var result = _mapper.Map<List<ReviewModel>>(obj);
            return new BusinessResult(200, "Get Review by RestaurantId", result);
        }

        public async Task<IBusinessResult> UpdateReview(int Id, ReviewModel model)
        {
            var obj = await _unitOfWork.ReviewRepository.GetByIdAsync(Id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Review");}
            model.RestaurantId = obj.RestaurantId;
            _mapper.Map(model, obj);
            var updated = await _unitOfWork.ReviewRepository.UpdateAsync(obj);
            var result = _mapper.Map<Review>(updated);
            return new BusinessResult(200, "Updated successfully", result);
        }
        public async Task<IBusinessResult> GetReviewsForPartner(int restaurantId)
        {
            var obj = await _unitOfWork.ReviewRepository.GetReviewsByRestaurantIdAsync(restaurantId);
            var result = _mapper.Map<List<ReviewPartner>>(obj);
            return new BusinessResult(200, "Get Reviews", result);
        }
    }

}
