using Abp.Events.Bus;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using System.Collections.Generic;

namespace Examples.Charge.Domain.Events.Person
{
    public class PersonEventAdded : EventData
    {
        public string Name { get; private set; }

        //public ICollection<PersonPhone> Phones { get; private set; }

        //public PersonEventAdded(string name, ICollection<PersonPhone> phones)
        public PersonEventAdded(string name)
        {
            Name = name;
            //Phones = phones;
        }
    }
}
