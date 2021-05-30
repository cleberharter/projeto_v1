using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhone : AggregateRoot, IHasCreationTime
    {
        public int BusinessEntityID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }

        public Person Person { get; set; }

        public PhoneNumberType PhoneNumberType { get; set; }

        [NotMapped]
        public bool IsActive { get; set; }

        [NotMapped]
        public DateTime CreationTime { get; set; }

    }
}
