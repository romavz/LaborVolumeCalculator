using System.Reflection.PortableExecutable;
using System.Linq;
using System.Collections.Generic;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageLaborVolumeRepository : RepositoryBase<NirStageLaborVolume>, INirStageLaborVolumeRepository
    {
        public NirStageLaborVolumeRepository(DbContext context) : base(context)
        {
        }

        public async Task RemoveOutdatedAsync(int stageID, IEnumerable<int> actualItemsIDs)
        {
            var outdatedItems = await Items
                .Where(m => (m.StageID == stageID) && !actualItemsIDs.Contains(m.ID))
                .ToListAsync();

            RemoveRange(outdatedItems);
        }
        
    }
}