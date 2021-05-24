using Abp.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Exemples.Charge.Core.DomainObjects
{
    public abstract class BaseFilter<TEntity> where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> ToQuery();
    }
}
