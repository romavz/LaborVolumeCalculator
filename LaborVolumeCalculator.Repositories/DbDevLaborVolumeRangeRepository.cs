using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class DbDevLaborVolumeRangeRepository : RepositoryBase<DbDevLaborVolumeRange>, IRepository<DbDevLaborVolumeRange>
    {
        public DbDevLaborVolumeRangeRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<DbDevLaborVolumeRange> WithIncludes 
        {
            get 
            {
                return GetAll()
                    .Include(m => m.Labor)
                        .ThenInclude(l => l.LaborCategory)
                    .Include(m => m.DbEntityCountRange);
            }
        }
    }
}