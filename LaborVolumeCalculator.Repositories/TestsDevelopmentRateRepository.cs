using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class TestsDevelopmentRateRepository : RepositoryBase<TestsDevelopmentRate>, IRepository<TestsDevelopmentRate>
    {
        public TestsDevelopmentRateRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<TestsDevelopmentRate> WithIncludes => GetAll()
            .Include(m => m.TestsScale)
            .Include(m => m.TestsCoverageLevel)
            .Include(m => m.ComponentsMicroArchitecture);
    }
}