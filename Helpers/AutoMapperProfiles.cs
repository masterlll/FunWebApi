using System.Linq;
using AutoMapper;
using FunWebApi.Dtos;
using FunWebApi.Models;

namespace FunWebApi.Helpers
{
    public class AutoMapperProfiles : Profile
    {


        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(x=>x.PhotoUrl, a=>{
            a.MapFrom(source =>source.Photos.FirstOrDefault( c=>c.IsMain).Url);
            })
            .ForMember(x=>x.Age ,a=>{
                 a.MapFrom(x=>x.DateofBirth.CalculateAge());
            });

            CreateMap<User, UserForDetailedDto>()
             .ForMember(x=>x.PhotoUrl, a=>{
            a.MapFrom(source =>source.Photos.FirstOrDefault( c=>c.IsMain).Url);
            })
             .ForMember(x=>x.Age ,a=>{
                 a.MapFrom(x=>x.DateofBirth.CalculateAge());
            });
            
            CreateMap<Photo, PhotoForDetailedDto>();

            CreateMap<UserForUpdateDto,User >();

            CreateMap<Photo,PhotoForReturnDto>();
              
            CreateMap<PhotoForCreationDto, Photo>();

        
        }

    }
}