using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly DbSet<TEntity> _items;
        protected readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _items = context.Set<TEntity>();
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        protected DbSet<TEntity> Items { get => _items; }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition)
        {
            return Items.Where(condition).AsNoTracking();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Items.AsNoTracking();
        }

        public virtual IQueryable<TEntity> WithIncludes
        {
            get 
            {
                throw new NotImplementedException("override this method in children classes if applicable");
            }
        }

        public virtual void Add(TEntity item)
        {
            Items.Add(item);
        }
        
        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public virtual void UpdateRecursive(TEntity item)
        {
            Items.Update(item);
        }

        public virtual void Remove(TEntity item)
        {
            Items.Remove(item);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> items)
        {
            Items.RemoveRange(items);
        }

        public virtual void RemoveItems(Expression<Func<TEntity, bool>> predicate)
        {
            var itemsList = Items
                .Where(predicate)
                .ToList();
            
            RemoveRange(itemsList);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Items.AsNoTracking().Any(predicate);
        }

        public bool Any()
        {
            return Items.AsNoTracking().Any();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Items.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

    }
}