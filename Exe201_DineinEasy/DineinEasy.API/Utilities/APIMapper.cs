using AutoMapper;
using AutoMapper.Internal;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.API.RequestDTO.Review;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;

namespace DineinEasy.API.Utilities
{
    public class APIMapper:Profile
    {
        public APIMapper() {
            RestaurantProfile();
            UserProfile();
            PackageProfile();
            AreaProfile();
            CategoryProfile();
            BannerProfile();
            TimeFrameProfile();
        }
        public void RestaurantProfile()
        {
            CreateMap<CreatedRestaurant, RestaurantModel>()
                .ForMember(dest => dest.RestaurantImages, opt =>opt.MapFrom(x=>x.RestaurantImages))
                .ReverseMap();
            CreateMap<CreatedImage, RestaurantImageModel>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ReverseMap();
            CreateMap<RestaurantModel, UpdatedRestaurant>()
               .ForMember(x => x.RestaurantImages, otp => otp.MapFrom(x => x.RestaurantImages.Select(y => y.ImageUrl)))
               .ReverseMap();
            CreateMap<Restaurant, RestaurantModel>()
               .ForMember(x => x.RestaurantImages, otp => otp.MapFrom(y => y.RestaurantImages))
               .ReverseMap();
            CreateMap<RestaurantImage, RestaurantImageModel>()
                .ReverseMap();
        }
        public void UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
        public void PackageProfile()
        {
            CreateMap<Package, PackageModel>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        public void AreaProfile()
        {
            CreateMap<Area, AreaModel>().ReverseMap()
                .ForMember(dest => dest.Id, opt => opt.Ignore()); ;
        }
        public void CategoryProfile()
        {
            CreateMap<Category, CategoryModel>().ReverseMap()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        public void BannerProfile()
        {
            CreateMap<Banner, BannerModel>().ReverseMap()
                     .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        public void TimeFrameProfile()
        {
            CreateMap<TimeFrame, TimeFrameModel>().ReverseMap()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        public void ReviewProfile()
        {
            CreateMap<Review, ReviewModel>()
                .ForMember(x => x.ReviewImages, otp => otp.MapFrom(x => x.ReviewImages))
                .ReverseMap();
            CreateMap<ReviewImage, ReviewImageModel>().ReverseMap();
            CreateMap<CreatedReview,ReviewModel>()
                .ForMember(x=>x.ReviewImages,otp => otp.MapFrom(x => x.Images)).ReverseMap();
            CreateMap<ReviewImage, CreatedImage>()
                .ForMember(x => x.ImageUrl, otp => otp.MapFrom(x => x.ImageUrl)).ReverseMap();
            CreateMap<UpdatedReview, ReviewModel>().ReverseMap();
        }
    }
}
