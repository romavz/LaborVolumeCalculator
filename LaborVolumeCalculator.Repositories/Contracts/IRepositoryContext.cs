using System.Threading.Tasks;

namespace LaborVolumeCalculator.Repositories.Contracts
{
    public interface IRepositoryContext
    {
        INirStageRepository NirStages { get; }
        INirStageLaborVolumeRepository NirStageLaborVolumes { get; }

        Task<int> SaveChangesAsync();
    }
}