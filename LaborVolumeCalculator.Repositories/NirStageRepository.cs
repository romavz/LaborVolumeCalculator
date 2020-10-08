using System.Linq;
using System;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageRepository : RepositoryBase<NirStage>, INirStageRepository
    {
        protected readonly INirStageLaborVolumeRepository laborsVolumes;

        public NirStageRepository(DbContext context, INirStageLaborVolumeRepository laborsVolumes) : base(context)
        {
            this.laborsVolumes = laborsVolumes;
        }

        public override IQueryable<NirStage> WithIncludes
        {
            get 
            {
                return Items
                    .Include(m => m.NirInnovationRate)
                    .Include(m => m.LaborVolumes)
                        .ThenInclude(lv => lv.Labor)
                    .AsNoTracking();
            }
        }

        public override void Update(NirStage item)
        {
            laborsVolumes.RemoveOutdated(item.ID, item.LaborVolumes.Select(m => m.ID));
            base.Update(item);
        }

        
    }
}