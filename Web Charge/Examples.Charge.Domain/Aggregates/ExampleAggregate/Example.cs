
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examples.Charge.Domain.Aggregates.ExampleAggregate
{
    public class Example : AggregateRoot, IHasCreationTime
    {
        public string Nome { get; set; }

        [NotMapped]
        public DateTime CreationTime { get; set; }

        public Example()
        {
            this.CreationTime = DateTime.Now;
        }
    }
}
