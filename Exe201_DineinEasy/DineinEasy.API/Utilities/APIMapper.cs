using AutoMapper;
using AutoMapper.Internal;
using DineinEasy.API.RequestDTO.Restaurant;
using DineinEasy.API.RequestDTO.User;
using DineinEasy.API.RequestDTO.Review;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;
using DineinEasy.API.RequestDTO.Customer;
using DineinEasy.API.RequestDTO.PartnerDTO;
using DineinEasy.Service.Models.PartnerModels;
using static DineinEasy.Service.Models.PartnerModels.PartnerModel;

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
            CustomerProfile();
            ReviewProfile();

        }

        public void CustomerProfile()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<CreatedCustomer, CustomerModel>();
            CreateMap<UpdatedCustomer, CustomerModel>();
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
            CreateMap<Data.Models.Restaurant, RestaurantModel>()
               .ForMember(x => x.RestaurantImages, otp => otp.MapFrom(y => y.RestaurantImages))
               .ReverseMap();

            CreateMap<RestaurantImage, RestaurantImageModel>()
                .ReverseMap();

            CreateMap<RestaurantPartner, Restaurant>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                 .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                 .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar))
                 .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Latitude))
                 .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Longtitude))
                 .ReverseMap()
                 ;

            CreateMap<TimeFramePartner, TimeFrame>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Day))
                .ForMember(dest => dest.OpenedTime, opt => opt.MapFrom(src => src.Open))
                .ForMember(dest => dest.ClosedTime, opt => opt.MapFrom(src => src.Close))
                .ReverseMap();
        }
        public void UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<CreatedUser, UserModel>();
            CreateMap<UpdatedUser, UserModel>();
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
                .ForMember(dest => dest.ReviewImages, opt => opt.MapFrom(src => src.ReviewImages))
                .ReverseMap();

            CreateMap<ReviewImage, ReviewImageModel>().ReverseMap();

            CreateMap<CreatedReview, ReviewModel>()
                .ForMember(dest => dest.ReviewImages, opt => opt.MapFrom(src => src.Images))
                .ReverseMap();

            CreateMap<ReviewImage, CreatedImage>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                .ReverseMap();

            CreateMap<UpdatedReview, ReviewModel>().ReverseMap();
            CreateMap<Review, ReviewPartner>()
                    .ForMember(dest => dest.imageUrls, opt => opt.MapFrom(src => src.ReviewImages))
                    .ForPath(dest => dest.Name,otp => otp.MapFrom(src => src.Customer.Name))
                    .ForPath(dest => dest.Phone, otp => otp.MapFrom(src => src.Customer.Phone))
                    .ReverseMap()
                    ;
                    
            CreateMap<ReviewImage, ImageReview>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUrl));
             
        }
        public void ImageRestaurantProfile()
        {
            CreateMap<RestaurantImage,RestaurantImageModel>().ReverseMap();
        }
    }
}
