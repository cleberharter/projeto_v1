using Examples.Charge.Core.Extensions;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Filters;
using System;
using System.Linq.Expressions;

namespace Examples.Charge.Domain.Queries
{
    public static class PersonQuery
    {
        public static Expression<Func<Person, bool>> GetQuery(PersonFilter filter)
        {
            Expression<Func<Person, bool>> expression = query => true;

            if (!string.IsNullOrEmpty(filter.Name))
                expression = expression.And(x => x.Name.Contains(filter.Name));

            return expression;
        }
    }
}
