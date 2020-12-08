using System.Linq;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirInnovationRateRepository : RepositoryBase<NirInnovationRate>, IRepository<NirInnovationRate>
    {
        public NirInnovationRateRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<NirInnovationRate> WithIncludes => GetAll()
            .Include(r => r.NirInnovationProperty)
            .Include(r => r.NirScale);
    }
}