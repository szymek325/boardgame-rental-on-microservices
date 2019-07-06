using AutoMapper;
using Games.Api.DataAccess.Entities;
using Games.Api.Dto;

namespace Games.Api.MapperConfiguration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateGameInput, Game>();
        }
    }
}