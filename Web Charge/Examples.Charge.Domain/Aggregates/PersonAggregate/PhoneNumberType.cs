using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberType : AggregateRoot, IHasCreationTime
    {
        [Column("PhoneNumberTypeID")]
        public override int Id { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public DateTime CreationTime { get; set; }
    }
}
