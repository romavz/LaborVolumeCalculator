using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class RangeFeatureRepository : RepositoryBase<RangeFeature>, IRepository<RangeFeature>
    {
        public RangeFeatureRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<RangeFeature> WithIncludes => GetAll()
            .Include(m => m.RangeFeatureCategory);
    }
}