using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirSoftwareDevLaborVolumeRepository : RepositoryBase<NirSoftwareDevLaborVolume>, IRepository<NirSoftwareDevLaborVolume>
    {
        public NirSoftwareDevLaborVolumeRepository(DbContext context, IRepository<NirStageSoftwareDevLaborGroup> laborGroup) : base(context)
        {
            laborGroup.UpdateRecursiveEvent += OnLaborGroupRecursiveUpdate;
        }

        private void OnLaborGroupRecursiveUpdate(NirStageSoftwareDevLaborGroup laborGroup)
        {
            var actualItemsIDs = laborGroup.LaborVolumes.Select(m => m.ID);
            RemoveOutdated(m => m.SoftwareDevLaborGroupID == laborGroup.ID && !actualItemsIDs.Contains(m.ID));
        }
    }
}