using System.Reflection.PortableExecutable;
using System.Linq;
using System.Collections.Generic;
using LaborVolumeCalculator.Data;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageLaborVolumeRepository : RepositoryBase<NirStageLaborVolume>, INirStageLaborVolumeRepository
    {
        public NirStageLaborVolumeRepository(DbContext context) : base(context)
        {
        }

        public void RemoveOutdated(int stageID, IEnumerable<int> actualItemsIDs)
        {
            var outdatedItems = Items.Where(m => (m.StageID == stageID) && !actualItemsIDs.Contains(m.ID));
            RemoveRange(outdatedItems);
        }
        
    }
}