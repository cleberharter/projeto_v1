using Examples.Charge.Application.Dtos.Person;
using Examples.Charge.Core.Notifications;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Validations.Person
{
    public interface IPersonValidator
    {
        Task<NotificationContext> ValidateCreateAsync(AddOrUpdatePersonDto personDto);

        Task<NotificationContext> ValidateUpdateAsync(int personId, AddOrUpdatePersonDto personDto);

        Task<NotificationContext> ValidateRemoveAsync(int person);
    }
}
