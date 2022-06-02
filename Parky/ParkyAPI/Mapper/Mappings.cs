using AutoMapper;
using ParkyAPI.DAL.Entities;
using ParkyAPI.DTOs;

namespace ParkyAPI.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
        }
    }
}
