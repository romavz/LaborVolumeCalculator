using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageSoftwareDevLaborGroupRepository : RepositoryBase<NirSoftwareDevLaborGroup>, INirStageSoftwareDevLaborGroupRepository
    {
        public NirStageSoftwareDevLaborGroupRepository(DbContext context) : base(context)
        {
        }
    }
}