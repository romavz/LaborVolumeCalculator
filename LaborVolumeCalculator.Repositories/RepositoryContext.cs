using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class RepositoryContext : IRepositoryContext
    {
        private readonly DbContext context;

        public RepositoryContext(LVCContext context)
        {
            this.context = context;
        }

        protected INirStageRepository _nirStages;
        public INirStageRepository NirStages
        {
            get 
            {
                _nirStages ??= new NirStageRepository(context, NirStageLaborVolumes);
                return _nirStages;
            }
        }

        protected INirStageLaborVolumeRepository _nirStageLaborVolumes;
        public INirStageLaborVolumeRepository NirStageLaborVolumes
        { 
            get 
            {
                _nirStageLaborVolumes ??= new NirStageLaborVolumeRepository(context);
                return _nirStageLaborVolumes;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}