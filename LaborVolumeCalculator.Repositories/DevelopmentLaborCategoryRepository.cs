using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class DevelopmentLaborCategoryRepository : RepositoryBase<DevelopmentLaborCategory>, IRepository<DevelopmentLaborCategory>
    {
        public DevelopmentLaborCategoryRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<DevelopmentLaborCategory> WithIncludes => GetAll()
            .Include(m => m.Labors);
    }
}