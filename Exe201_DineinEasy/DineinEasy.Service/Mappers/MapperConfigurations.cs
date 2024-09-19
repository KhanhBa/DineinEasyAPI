using AutoMapper;
using DineinEasy.Data.Models;
using DineinEasy.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Mappers
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            UserProfile();
            PackageProfile();
            AreaProfile();
            CategoryProfile();
            BannerProfile();
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
            CreateMap<Category,CategoryModel>().ReverseMap()
                 .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
        public void BannerProfile() 
        {
            CreateMap<Banner,BannerModel>().ReverseMap()
                     .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
