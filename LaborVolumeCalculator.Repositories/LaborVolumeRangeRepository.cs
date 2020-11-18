using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class LaborVolumeRangeRepository : RepositoryBase<LaborVolumeRange>, IRepository<LaborVolumeRange>
    {
        public LaborVolumeRangeRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<LaborVolumeRange> WithIncludes => GetAll()
            .Include(m => m.Labor)
                .ThenInclude(l => l.LaborCategory)
            .Include(m => m.RangeFeature)
                .ThenInclude(rf => rf.Category);
    }
}