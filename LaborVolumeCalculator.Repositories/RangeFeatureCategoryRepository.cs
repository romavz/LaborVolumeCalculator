using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class RangeFeatureCategoryRepository : RepositoryBase<RangeFeatureCategory>, IRepository<RangeFeatureCategory>
    {
        public RangeFeatureCategoryRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<RangeFeatureCategory> WithIncludes => GetAll()
            .Include(m => m.RangeFeatures);
    }
}