using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class DbDevLaborRepository : RepositoryBase<DbDevLabor>, IRepository<DbDevLabor>
    {
        public DbDevLaborRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<DbDevLabor> WithIncludes
        {
            get 
            {
                return GetAll().Include(m => m.LaborCategory);
            }
        }
    }
}