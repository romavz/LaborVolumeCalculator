using System.Linq;
using System;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageRepository : RepositoryBase<NirStage>, IRepository<NirStage>
    {
        protected readonly IRepository<NirStageLaborVolume> laborsVolumes;
        private readonly IRepository<NirStageSoftwareDevLaborGroup> sdlvGroups;
        private readonly IRepository<NirStageOntdLaborVolume> ontdLaborsVolumes;

        public NirStageRepository(DbContext context,
            IRepository<NirStageLaborVolume> laborsVolumes,
            IRepository<NirStageSoftwareDevLaborGroup> sdlvGroups,
            IRepository<NirStageOntdLaborVolume> ontdLaborsVolumes
            ) : base(context)
        {
            this.laborsVolumes = laborsVolumes;
            this.sdlvGroups = sdlvGroups;
            this.ontdLaborsVolumes = ontdLaborsVolumes;
        }

        public override IQueryable<NirStage> WithIncludes
        {
            get 
            {
                return Items
                    .Include(m => m.NirInnovationRate)
                    .Include(m => m.LaborVolumes)
                        .ThenInclude(lv => lv.Labor)
                    .Include(m => m.OntdLaborVolumes)
                        .ThenInclude(lv => lv.Labor)
                    .Include(m => m.SoftwareDevLaborGroups)
                        .ThenInclude(g => g.SoftwareDevLaborGroup)
                    .Include(m => m.SoftwareDevLaborGroups)
                        .ThenInclude(m => m.LaborVolumes)
                            .ThenInclude(lv => lv.LaborVolumeRange)
                                .ThenInclude(lvr => lvr.Labor)
                                    .ThenInclude(l => l.LaborCategory)
                    .Include(m => m.SoftwareDevLaborGroups)
                        .ThenInclude(m => m.LaborVolumes)
                            .ThenInclude(lv => lv.LaborVolumeRange)
                                .ThenInclude(r => r.RangeFeature)
                                    .ThenInclude(f => f.RangeFeatureCategory)
                    .AsNoTracking();
            }
        }

        public override void UpdateRecursive(NirStage item)
        {
            RemoveOutdatedIncludes(item);
            base.UpdateRecursive(item);
        }

        /// <summary>
        /// Отмечает на удаление неактуальные элементы: <br/>
        ///     - Трудозатраты Этапа; <br/>
        ///     - Группы трудозатрат СПО Этапа; <br/>
        ///     - Трудозатраты ОНТД Этапа;
        /// </summary>
        /// <param name="stage"> Этап НИР </param>
        protected virtual void RemoveOutdatedIncludes(NirStage stage)
        {
            laborsVolumes.RemoveItems(m => m.StageID == stage.ID);
            sdlvGroups.RemoveItems(m => m.StageID == stage.ID);
            ontdLaborsVolumes.RemoveItems(m => m.StageID == stage.ID);
        }        
    }
}