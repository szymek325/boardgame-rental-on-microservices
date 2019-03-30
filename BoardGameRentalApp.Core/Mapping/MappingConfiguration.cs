﻿using AutoMapper;
using BoardGameRentalApp.Core.Dto.BoardGames;
using BoardGameRentalApp.Core.Dto.Clients;
using BoardGameRentalApp.Core.Entities;

namespace BoardGameRentalApp.Core.Mapping
{
    internal class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<CreateBoardGameInput, BoardGame>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.Bail, opt => opt.MapFrom(src => src.Bail))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.GameRentals, opt => opt.Ignore());

            CreateMap<BoardGame, BoardGameDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.PricePerDay, opt => opt.MapFrom(src => src.PricePerDay))
                .ForMember(dest => dest.Bail, opt => opt.MapFrom(src => src.Bail))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
                .ReverseMap();

            CreateMap<CreateClientInput, Client>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
                .ForMember(dest => dest.GameRentals, opt => opt.Ignore());

            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.CreationTime, opt => opt.MapFrom(src => src.CreationTime))
                .ReverseMap();
        }
    }
}