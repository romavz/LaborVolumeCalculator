using System.Collections.Generic;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Repositories.Contracts
{
    public interface INirStageLaborVolumeRepository : IRepositoryBase<NirStageLaborVolume>
    {
        void RemoveOutdated(int stageID, IEnumerable<int> actualItemsIDs);
    }
}