using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Examples.Charge.Domain.Events.Person;

namespace Examples.Charge.Domain.Handlers
{
    public class PersonAddedHandler : IEventHandler<PersonEventAdded>, ITransientDependency
    {
        public void HandleEvent(PersonEventAdded eventData)
        {
        }
    }
}