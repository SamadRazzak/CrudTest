using AutoMapper;
using CrudTest.API.Entities;
using CrudTest.API.Models.DTOs;

namespace CrudTest.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UsersDto, User>().ReverseMap();
        }        
    }
}
