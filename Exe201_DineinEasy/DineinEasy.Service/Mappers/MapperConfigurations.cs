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
        }
        public void UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
        }
        public void PackageProfile()
        {
            CreateMap<Package, PackageModel>().ReverseMap();
        }
        public void AreaProfile()
        {
            CreateMap<Area, AreaModel>().ReverseMap();
        }
    }
}
