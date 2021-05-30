using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {

            CreateMap<PhoneNumberTypeDto, PhoneNumberType>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PersonPhoneDto, PersonPhone>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
               .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
               .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumberType));

            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(s => s.Phones));

            CreateMap<AddOrUpdatePersonDto, Person>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(src => src.Phones));

        }
    }
}