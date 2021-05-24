using AutoMapper;
using Examples.Charge.Application.Common;
using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Application.Validations.Person;
using Examples.Charge.Core.Notifications;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IPersonValidator _personValidator;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService,
                            IPersonValidator personValidator,
                            IMapper mapper)
        {
            _mapper = mapper;
            _personService = personService;
            _personValidator = personValidator;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonListResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonDto> FindAsync(int Id)
            => _mapper.Map<PersonDto>(await _personService.FindAsync(Id));


        public async Task<ApplicationDataResult<PersonDto>> AddAsync(AddOrUpdatePersonDto personDto)
        {
            NotificationContext result = await _personValidator.ValidateCreateAsync(personDto);

            if (result.HasNotifications)
                return ApplicationDataResult<PersonDto>.FactoryFromNotificationContext(result);

            Person person = _mapper.Map<Person>(personDto);

            await _personService.AddAsync(person);

            return ApplicationDataResult<PersonDto>.FactoryFromData(_mapper.Map<PersonDto>(person));
        }

        public async Task<ApplicationDataResult<PersonDto>> UpdateAsync(int Id,
            AddOrUpdatePersonDto personDto)
        {
            NotificationContext result = await _personValidator.ValidateUpdateAsync(Id, personDto);

            if (result.HasNotifications)
                return ApplicationDataResult<PersonDto>.FactoryFromNotificationContext(result);

            Person person = _mapper.Map<Person>(personDto);
            await _personService.UpdateAsync(person);

            return ApplicationDataResult<PersonDto>.FactoryFromData(_mapper.Map<PersonDto>(person));
        }

        public async Task<ApplicationDataResult<PersonDto>> RemoveAsync(int Id)
        {
            NotificationContext result = await _personValidator.ValidateRemoveAsync(Id);

            if (result.HasNotifications)
                return ApplicationDataResult<PersonDto>.FactoryFromNotificationContext(result);

            await _personService.RemoveAsync(Id);

            return ApplicationDataResult<PersonDto>.FactoryFromEmpty();
        }
    }
}
