using Abp.Events.Bus;

namespace Examples.Charge.Domain.Events.Person
{
    public class PersonEventAdded : EventData
    {
        public string Name { get; private set; }

        public PersonEventAdded(string name)
        {
            Name = name;
        }
    }
}
