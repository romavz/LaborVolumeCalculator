using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class ArchitectureComplexityRateRepository : RepositoryBase<ArchitectureComplexityRate>, IRepository<ArchitectureComplexityRate>
    {
        public ArchitectureComplexityRateRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<ArchitectureComplexityRate> WithIncludes => GetAll()
            .Include(m => m.ComponentsInteractionArchitecture)
            .Include(m => m.ComponentsMakroArchitecture);
        
    }
}