using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Examples.Charge.Domain.Events.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class Person : AggregateRoot, IHasCreationTime
    {
        [Column("BusinessEntityID")]
        public override int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("BusinessEntityID")]
        public ICollection<PersonPhone> Phones { get; set; }

        [NotMapped]
        public DateTime CreationTime { get; set; }

        public Person()
        {
            this.CreationTime = DateTime.Now;
        }

        public void AddItem(PersonPhone item)
        {

        }

        public void Add(string personName)
        {
            DomainEvents.Add(new PersonEventAdded(personName));
        }
    }
}
