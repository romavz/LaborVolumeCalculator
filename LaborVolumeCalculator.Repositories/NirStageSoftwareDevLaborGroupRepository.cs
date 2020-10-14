using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageSoftwareDevLaborGroupRepository : RepositoryBase<NirStageSoftwareDevLaborGroup>, IRepository<NirStageSoftwareDevLaborGroup>
    {
        public NirStageSoftwareDevLaborGroupRepository(DbContext context, INirStageRepository nirStageRepository) : base(context)
        {
            nirStageRepository.UpdateRecursiveEvent += OnNirStageRecursiveUpdate;
        }
       
        protected void OnNirStageRecursiveUpdate(NirStage nirStage)
        {
            var actualItemsIDs = nirStage.SoftwareDevLaborGroups.Select(m => m.ID);
            RemoveOutdated(m => m.StageID == nirStage.ID && !actualItemsIDs.Contains(m.ID));
        }

    }
}