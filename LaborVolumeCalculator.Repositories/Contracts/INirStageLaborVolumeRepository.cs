using System.Collections.Generic;
using System.Threading.Tasks;
using LaborVolumeCalculator.Models.Registers;

namespace LaborVolumeCalculator.Repositories.Contracts
{
    public interface INirStageLaborVolumeRepository : IRepository<NirStageLaborVolume>
    {
        Task RemoveOutdatedAsync(int stageID, IEnumerable<int> actualItemsIDs);
    }
}