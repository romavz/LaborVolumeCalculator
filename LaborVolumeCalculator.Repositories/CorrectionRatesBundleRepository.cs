using System.Runtime.CompilerServices;
using LaborVolumeCalculator.Repositories.Contracts;
using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LaborVolumeCalculator.Repositories
{
    public class CorrectionRatesBundleRepository : RepositoryBase<CorrectionRatesBundle>, IRepository<CorrectionRatesBundle>
    {
        public CorrectionRatesBundleRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<CorrectionRatesBundle> WithIncludes => this.GetAll()
            .Include(m => m.SolutionInnovationRate)
            .Include(m => m.StandardModulesUsingRate)
            .Include(m => m.ArchitectureComplexityRate)
                .ThenInclude(a => a.ComponentsInteractionArchitecture)
            .Include(m => m.ArchitectureComplexityRate)
                .ThenInclude(a => a.ComponentsMakroArchitecture)
            .Include(m => m.TestsDevelopmentRate)
                .ThenInclude(t => t.ComponentsMicroArchitecture)
            .Include(m => m.TestsDevelopmentRate)
                .ThenInclude(t => t.TestsCoverageLevel)
            .Include(m => m.TestsDevelopmentRate)
                .ThenInclude(t => t.TestsScale)
        ;

        
    }
}