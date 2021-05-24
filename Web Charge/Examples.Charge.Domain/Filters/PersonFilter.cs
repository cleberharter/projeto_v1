using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Queries;
using Exemples.Charge.Core.DomainObjects;
using System;
using System.Linq.Expressions;

namespace Examples.Charge.Domain.Filters
{
    public class PersonFilter : BaseFilter<Person>
    {
        public string Name { get; set; }

        public override Expression<Func<Person, bool>> ToQuery()
            => PersonQuery.GetQuery(this);
    }
}