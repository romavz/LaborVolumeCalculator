using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class SoftwareDevEnvRepository : RepositoryBase<SoftwareDevEnv>
    {
        public SoftwareDevEnvRepository(DbContext context) : base(context)
        {
        }
    }
}