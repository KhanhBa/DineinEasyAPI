using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Data.UnitOfWork;
using DineinEasy.Service.Models;
using DineinEasy.Service.Models.PartnerModels;
using DineinEasy.Service.Responses;
using DineinEasy.Service.Untils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

namespace DineinEasy.Service.Services
{
    public interface IRestaurantService
    {
        Task<IBusinessResult> CreateRestaurant(RestaurantModel model);
        Task<IBusinessResult> UpdateRestaurant(RestaurantModel restaurant,int id);
        Task<IBusinessResult> DeleteRestaurant(int id);
        Task<IBusinessResult> GetAllRestaurants();
        Task<IBusinessResult> GetRestaurantById(int id);
        Task<IBusinessResult> SignIn(string email, string password);
        public  Task<IBusinessResult> GetImageRestaurantById(int id);
        Task<IBusinessResult> GetInfomationForPartner(int restaurant);
        Task<IBusinessResult> GetReviewsRestaurantById(int id);
        public Task<IBusinessResult> GetBannersByRestaurantId(int id);
        Task<IBusinessResult> GetImagesByRestaurantId(int id);
        Task<IBusinessResult> ChangeImageRestaurant(int restaurantId , List<RestaurantImageModel> list);
        Task<IBusinessResult> ChangeStatus(int id, int status);
    }
    public class RestaurantService : IRestaurantService
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

        public async Task<IBusinessResult> SignIn(string email, string password)
        {
                if (string.IsNullOrEmpty(email))
                    return new BusinessResult()
                    {
                        Data = null,
                        Message = "email is empty.",
                        Status = 400
                    };

                if (string.IsNullOrEmpty(password))
                    return new BusinessResult()
                    {
                        Data = null,
                        Message = "password is empty.",
                        Status = 400
                    };

                var restaurants = await _unitOfWork.RestaurantRepository.GetAllAsync(x => x.Email == email.ToLower().Trim() && x.Password == password);

                if (restaurants.Count == 0)
                    return new BusinessResult()
                    {
                        Data = null,
                        Message = "email/password is incorrect.",
                        Status = 404
                    };
                var restaurant = restaurants.FirstOrDefault();

                JwtSecurityToken accessJwtSecurityToken = JWTHelper.GetToken("RESTAURANT", restaurant.Id, restaurant.Name, restaurant.Email, 1,null);
                JwtSecurityToken refreshJwtSecurityToken = JWTHelper.GetToken("RESTAURANT", restaurant.Id, restaurant.Name, restaurant.Email, 3,null);

                SignInModel<RestaurantModel> signInModel = new SignInModel<RestaurantModel>()
                {
                AccessToken= new JwtSecurityTokenHandler().WriteToken(accessJwtSecurityToken),
                RefreshToken= new JwtSecurityTokenHandler().WriteToken(refreshJwtSecurityToken),
                Data=_mapper.Map<RestaurantModel>(restaurant)
                 };
                 return new BusinessResult()
                {
                    Data = signInModel,
                    Status = 200,
                    Message = "signing in successfully."
                };
            
        }

        public async Task<IBusinessResult> GetImageRestaurantById(int id)
        {
            var obj = await _unitOfWork.RestaurantImageRepository.FindByConditionAsync(x=>x.RestaurantId==id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find restaurant's images"); }
            var result = _mapper.Map<List<RestaurantImageModel>>(obj);
            return new BusinessResult(200, "Get restaurant's images successfully", result);
        }
        public async Task<IBusinessResult> GetReviewsRestaurantById(int id)
        {
            var obj = await _unitOfWork.ReviewRepository.FindByConditionAsync(x => x.RestaurantId == id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find restaurant's reviews"); }
            var result = _mapper.Map<List<ReviewModel>>(obj);
            return new BusinessResult(200, "Get restaurant's reviews successfully", result);
        }


        public async Task<IBusinessResult> GetBannersByRestaurantId(int id)
        {
            var obj = await _unitOfWork.BannerRepository.FindByConditionAsync(x => x.RestaurantId == id);
            if (obj == null)
            { return new BusinessResult(404, "Can not find Banner"); }
            var result = _mapper.Map<List<BannerModel>>(obj);
            return new BusinessResult(200, "Get Banner by Id successfully", result);
        }

        public async Task<IBusinessResult> GetInfomationForPartner(int restaurant)
        {
            var obj = await _unitOfWork.RestaurantRepository.GetRestaurantForPartner(restaurant);
            if (obj == null) {
                new BusinessResult(400, "Can not find Restaurant");
            }
            var result = _mapper.Map<RestaurantPartner>(obj);
            return new BusinessResult(200, "Get Restaurant by Id successfully", result);
        }

        public async Task<IBusinessResult> ChangeStatus(int id, int status)
        {
            var obj = await _unitOfWork.RestaurantRepository.GetByIdAsync(id);
            if (obj == null) { return new BusinessResult(404, "Can not find Restaurant"); }
            obj.Status = status == 1;
            var updated = await _unitOfWork.RestaurantRepository.UpdateAsync(obj);
            var result = _mapper.Map<RestaurantModel>(obj);
            return new BusinessResult(200, "Update successfully", result);
        }
        public async Task<IBusinessResult> GetImagesByRestaurantId(int id)
        {
            var obj = await _unitOfWork.RestaurantImageRepository.GetRestaurantImagesAsync(id);
            if (obj == null)
            {
                new BusinessResult(200, "Do not have any image");
            }
            var result = _mapper.Map<List<RestaurantImage>>(obj);
            return new BusinessResult(200, "Get Images by Id successfully", result);
        }
        public async Task<IBusinessResult> ChangeImageRestaurant(int restaurantId, List<RestaurantImageModel> list)
        {
            await _unitOfWork.RestaurantImageRepository.DeleteAllImage(restaurantId);
            var result = new List<RestaurantImageModel>();
            foreach (var image in list) { 
                var obj = _mapper.Map<RestaurantImage>(image);
                obj.RestaurantId = restaurantId;
                obj.Id = 0;
                var newObj = await _unitOfWork.RestaurantImageRepository.CreateAsync(obj);
                result.Add(_mapper.Map<RestaurantImageModel>(newObj));
            }
            _unitOfWork.RestaurantRepository.Save();
            return new BusinessResult(200, "Change successfully", result);
        }
    }
}
