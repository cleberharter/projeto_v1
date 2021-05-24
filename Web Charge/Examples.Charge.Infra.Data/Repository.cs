using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Exemples.Charge.Core.Data;
using Examples.Charge.Infra.Data.Context;
using Exemples.Charge.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Examples.Charge.Core.Data;

namespace Examples.Charge.Infra.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>, IHasCreationTime
    {
        public IUnitOfWork UnitOfWork { get; set; }
        protected readonly ExampleContext _context;

        protected Repository(ExampleContext context)
        {
            _context = context;
            UnitOfWork = _context;
        }

        public async Task AddAsync(TEntity entity)
            => await _context.Set<TEntity>().AddAsync(entity);

        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> FilterAsync<TFilter>(TFilter filter) where TFilter : BaseFilter<TEntity>
            => BuidQueryable(new Pagination(), filter)
                .ToListAsync();

        public Task<List<TEntity>> FilterAsync<TFilter>(Pagination pagination, TFilter filter) where TFilter : BaseFilter<TEntity>
            => BuidQueryable(pagination, filter)
                .ToListAsync();

        public Task<int> CountAsync<TFilter>(TFilter filter) where TFilter : BaseFilter<TEntity>
           => _context.Set<TEntity>()
               .AsNoTracking()
               .Where(filter.ToQuery())
               .CountAsync();

        public async Task<Pageable<TEntity>> FilterPaginateAsync<TFilter>(Pagination pagination, TFilter filter)
            where TFilter : BaseFilter<TEntity>
        {
            int total = await CountAsync(filter);

            List<TEntity> data = await BuidQueryable(pagination, filter).ToListAsync();

            return FactoryPageable<TEntity>(data, total, pagination.Skip ?? 0, pagination.Take ?? 30);
        }

        public Task<TEntity> FindAsync(int id)
            => EF.CompileAsyncQuery((ExampleContext context, int idInner) =>
                context.Set<TEntity>()
                    .FirstOrDefault(c => c.Id == idInner)).Invoke(_context, id);

        public Task<TEntity> FindAsync<TFilter>(TFilter filter) where TFilter : BaseFilter<TEntity>
            => BuidQueryable(new Pagination(), filter)
                .FirstOrDefaultAsync();

        private IQueryable<TEntity> BuidQueryable<TFilter>(Pagination pagination, TFilter filter)
            where TFilter : BaseFilter<TEntity>
        {
            return _context.Set<TEntity>()
                .Where(filter.ToQuery())
                .OrderByDescending(x => x.CreationTime)
                .ConfigureSkipTakeFromPagination(pagination);

        }

        protected Pageable<TType> FactoryPageable<TType>(IList<TType> data, int total, int skip, int take) where TType : class
        {
            return new Pageable<TType>()
            {
                Data = data,
                Total = total,
                Pages = (int)Math.Ceiling(total / (decimal)(take)),
                CurrentPage = skip <= 0 ? 1 : skip
            };
        }

        public TEntity FirstOrDefault(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public TEntity Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int InsertAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public int InsertOrUpdateAndGetId(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Load(int id)
        {
            throw new NotImplementedException();
        }

        public long LongCount()
        {
            throw new NotImplementedException();
        }

        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
            => _context.Set<TEntity>().Update(entity);

        public TEntity Update(int id, Action<TEntity> updateAction)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(int id, Func<TEntity, Task> updateAction)
        {
            throw new NotImplementedException();
        }

        TEntity Abp.Domain.Repositories.IRepository<TEntity, int>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
