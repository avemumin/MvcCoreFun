﻿using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Domain.Entities;
using CDE = CarWorkshop.Domain.Entities;

namespace CarWorkshop.Application.Mappings;

public class CarWorkshopMappingProfile : Profile
{
    public CarWorkshopMappingProfile()
    {
        CreateMap<CarWorkshopDto, CDE.CarWorkshop>()
            .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new CarWorkshopContactDetails()
            {
                City = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode,
                Street = src.Street
            }));

        CreateMap<CDE.CarWorkshop, CarWorkshopDto>()
            .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
            .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
            .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode))
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber));

        CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
    }
}
