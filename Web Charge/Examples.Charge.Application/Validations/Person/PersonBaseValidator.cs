using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Core.Notifications;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Domain.Filters;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Validations.Person
{
    public class PersonBaseValidator : BaseValidator, IPersonValidator
    {
        private readonly IPersonRepository _personRepository;

        /// <summary>
        /// Method responsible for initialize validator.
        /// </summary>
        /// <param name="personRepository"></param>
        public PersonBaseValidator(IPersonRepository personRepository)
            => _personRepository = personRepository;

        /// <summary>
        /// Method responsible for validation.
        /// </summary>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public async Task<NotificationContext> ValidateCreateAsync(AddOrUpdatePersonDto personDto)
        {
            NotificationContext notificationContext = new NotificationContext();

            await ValidateDTOAsync(notificationContext, personDto);

            if (string.IsNullOrEmpty(personDto.Name)) return notificationContext;

            Domain.Aggregates.PersonAggregate.Person result = await _personRepository.FindAsync(new PersonFilter { Name = personDto.Name });
            
            if (result != null)
                notificationContext.AddNotification(
                    CreateNotification(nameof(Person), ApplicationValidationMessages.PersonFoundByDescription));

            return notificationContext;
        }

        /// <summary>
        /// Method responsible for validation.
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="personDto"></param>
        /// <returns></returns>
        public async Task<NotificationContext> ValidateUpdateAsync(int personId, AddOrUpdatePersonDto personDto)
        {
            NotificationContext notificationContext = new NotificationContext();

            await ValidateDTOAsync(notificationContext, personDto);

            Domain.Aggregates.PersonAggregate.Person person = await _personRepository.FindAsync(personId);

            if (person is null)
                return notificationContext.AddNotification(
                    CreateNotification(nameof(Person), ApplicationValidationMessages.PersonNotFoundById));

            if (string.IsNullOrEmpty(personDto.Name)) return notificationContext;

            Domain.Aggregates.PersonAggregate.Person result =
                await _personRepository.FindAsync(new PersonFilter { Name = personDto.Name });

            if (result != null && result.Id != personId)
                notificationContext.AddNotification(
                    CreateNotification(nameof(Person), ApplicationValidationMessages.PersonFoundByDescription));

            return notificationContext;
        }

        /// <summary>
        /// Method responsible for validation.
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        public async Task<NotificationContext> ValidateRemoveAsync(int personId)
        {
            NotificationContext notificationContext = new NotificationContext();

            Domain.Aggregates.PersonAggregate.Person person = await _personRepository.FindAsync(personId);

            if (person is null)
                return notificationContext.AddNotification(
                    CreateNotification(nameof(Person), ApplicationValidationMessages.PersonNotFoundById));

            return notificationContext;
        }

        /// <summary>
        /// Method responsible for validation.
        /// </summary>
        /// <param name="notificationContext"></param>
        /// <param name="personDto"></param>
        /// <returns></returns>
        private async Task ValidateDTOAsync(NotificationContext notificationContext, AddOrUpdatePersonDto personDto)
        {
            ValidationResult validationResult = await personDto.Validate();

            notificationContext.AddNotifications(validationResult);
        }
    }
}
