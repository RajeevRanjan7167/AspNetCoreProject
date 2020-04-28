using System.Linq;
using AspNetCoreApp.API.Dtos;
using AspNetCoreApp.API.Models;
using AutoMapper;
using AspNetCoreApp.API.Dtos.roleDTO;

namespace AspNetCoreApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ResourcesMST, ResourceForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.ismain).url))
                .ForMember(dest => dest.Age, opt =>
                        opt.MapFrom(src => src.rm_DateOfBirth.CalculateAge()));
            CreateMap<ResourcesMST, ResourceForDetailsDTO>()
                .ForMember(dest => dest.PhotoUrl, opt =>
                        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.ismain).url))
                .ForMember(dest => dest.Age, opt =>
                        opt.MapFrom(src => src.rm_DateOfBirth.CalculateAge()));                        
            CreateMap<Photo, photoForDetailDTO>();
            CreateMap<ResourceForRegisterDTO, ResourcesMST>();
            CreateMap<ResourceForUpdateDTO, ResourcesMST>(); 

            CreateMap<Roles, roleForListDTO>();           
            CreateMap<roleForCreateDTO, Roles>();
            CreateMap<roleForUpdateDTO, Roles>();
        }
    }
}