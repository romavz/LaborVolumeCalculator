using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirStageOntdLaborVolumeRepository : RepositoryBase<NirStageOntdLaborVolume>, IRepository<NirStageOntdLaborVolume>
    {
        public NirStageOntdLaborVolumeRepository(DbContext context, INirStageRepository nirStageRepository) : base(context)
        {
            nirStageRepository.UpdateRecursiveEvent += OnNirStageRecursiveUpdate;
        }

        protected void OnNirStageRecursiveUpdate(NirStage nirStage)
        {
            RemoveItems(m => m.StageID == nirStage.ID);
        }
    }
}