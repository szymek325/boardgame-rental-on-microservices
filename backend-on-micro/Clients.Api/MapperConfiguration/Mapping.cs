using AutoMapper;
using Clients.Api.DataAccess.Entities;
using Clients.Api.Dto;

namespace Clients.Api.MapperConfiguration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateClientInput, Client>();
        }
    }
}