using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Examples.Charge.Domain.Events.Person;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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

        public void Update(string name, ICollection<PersonPhone> phones)
        {
            this.Name = name;

            foreach (var item in phones)
            {
                var personPhone = this.Phones.Where(x => x.PhoneNumberTypeID == item.PhoneNumberTypeID).FirstOrDefault();
                
                item.IsActive = true;

                if (personPhone == null)
                {
                    this.Phones.Add(item);
                }
                else if (personPhone.PhoneNumber != item.PhoneNumber)
                {
                    this.Phones.Remove(personPhone);
                    this.Phones.Add(item);
                }
                else
                {
                    personPhone.IsActive = true;
                }
            }

            this.Phones.Where(x => !x.IsActive).ToList().ForEach(x => this.Phones.Remove(x));
        }

        public void Add(string personName)
        {
            DomainEvents.Add(new PersonEventAdded(personName));
        }
    }
}
