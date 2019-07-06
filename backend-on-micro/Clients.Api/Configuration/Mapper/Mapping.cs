using AutoMapper;
using Clients.Api.DataAccess.Entities;
using Clients.Api.Dto;

namespace Clients.Api.Configuration.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateClientInput, Client>();
        }
    }
}