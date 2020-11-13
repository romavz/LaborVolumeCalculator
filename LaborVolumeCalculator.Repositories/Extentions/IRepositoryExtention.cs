using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories.Extentions
{
    public static class IRepositoryExtention
    {
        public static Task<TEntity> FindAsync<TEntity>(this IQueryable<TEntity> repository, int id) where TEntity : class, IIdentable
        {
            return repository.FirstOrDefaultAsync(item => item.ID == id);
        }

        public static Task<TEntity> FindAsync<TEntity>(this IRepository<TEntity> repository, int id) where TEntity : class, IIdentable
        {
            return repository.FirstOrDefaultAsync(item => item.ID == id);
        }

        public static Task<List<TEntity>> ToListAsync<TEntity>(this IRepository<TEntity> repository) where TEntity : class
        {
            return repository.GetAll().ToListAsync();
        }

        
    }
}