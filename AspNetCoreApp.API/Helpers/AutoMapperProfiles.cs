using System.Linq;
using AspNetCoreApp.API.Dtos;
using AspNetCoreApp.API.Models;
using AutoMapper;
using AspNetCoreApp.API.Dtos.roleDTO;
using AspNetCoreApp.API.Dtos.groupDTO;
using AspNetCoreApp.API.Dtos.componentDTO;

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

            CreateMap<Roles, roleForListDTO>()
                .ForMember(dest => dest.strContext, opt =>
                        opt.MapFrom(src => src.is_active.strActive()));
            CreateMap<roleForCreateDTO, Roles>();
            CreateMap<roleForUpdateDTO, Roles>();

            CreateMap<Groups, groupForSelectDTO>();
            CreateMap<groupForCreateDTO, Groups>();
            CreateMap<groupForUpdateDTO, Groups>();

            CreateMap<components, componentForSelectDTO>();
            CreateMap<componentForCreateDTO, components>();
            CreateMap<componentForUpdateDTO, components>();
        }
    }
}