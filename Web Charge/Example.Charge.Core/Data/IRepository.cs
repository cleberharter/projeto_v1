using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Exemples.Charge.Core.Data;
using Exemples.Charge.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Core.Data
{
    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
    {
        IUnitOfWork UnitOfWork { get; set; }

        Task AddAsync(TEntity entity);

        void Remove(TEntity entity);

        Task<TEntity> FindAsync(int id);

        IQueryable<TEntity> GetIncluding(int id, params Expression<Func<TEntity, object>>[] propertySelectors);

        Task<TEntity> FindAsync<TFilter>(TFilter filter) where TFilter : BaseFilter<TEntity>;

        Task<List<TEntity>> FilterAsync<TFilter>(TFilter filter) where TFilter : BaseFilter<TEntity>;

        Task<Pageable<TEntity>> FilterPaginateAsync<TFilter>(Pagination pagination, TFilter filter)
            where TFilter : BaseFilter<TEntity>;

        Task<List<TEntity>> FilterAsync<TFilter>(Pagination pagination, TFilter filter) where TFilter : BaseFilter<TEntity>;
    }
}
