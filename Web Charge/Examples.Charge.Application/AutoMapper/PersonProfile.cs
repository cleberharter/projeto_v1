using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonPhone, PersonPhoneDto>();

            CreateMap<Person, PersonDto>()
               .ReverseMap()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.Phones, opt => opt.MapFrom(s => s.Phones));

            CreateMap<AddOrUpdatePersonDto, Person>()
               .ReverseMap()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}