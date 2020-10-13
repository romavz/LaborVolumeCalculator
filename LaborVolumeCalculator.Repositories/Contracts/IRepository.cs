using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LaborVolumeCalculator.Repositories.Contracts
{
    public interface IRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> WithIncludes { get; }

        void Add(TEntity entity);
        void Update(TEntity entity);
        void UpdateRecursive(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool Any(Expression<Func<TEntity, bool>> predicate);
        bool Any();

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChangesAsync();
    }
}