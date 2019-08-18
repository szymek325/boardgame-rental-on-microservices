﻿using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Rentals.Api.DataAccess.Entities;
using Rentals.Api.Dto;
using Rentals.Api.Models;

namespace Rentals.Api.MapperConfiguration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateRentalInput, Rental>()
                .ForMember(dest => dest.ClientId, opts => opts.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.RentedGames,
                    opts => opts.MapFrom(src => src.Products.ToList().Select(x => x.Id.ToString()).Join(";")))
                .ForMember(dest => dest.CreationTimeUtc, opts => opts.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => RentalStatus.InProgress));
        }
    }
}