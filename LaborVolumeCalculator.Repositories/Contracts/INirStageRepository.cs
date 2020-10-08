
using LaborVolumeCalculator.Models.Registers;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Repositories.Contracts
{
    public interface INirStageRepository : IRepositoryBase<NirStage>
    {
        /// <summary>
        /// Отмечает на удаление неактуальные элементы: <br/>
        ///     - Трудозатраты Этапа; <br/>
        ///     - Группы трудозатрат СПО Этапа; <br/>
        ///     - Трудозатраты ОНТД Этапа;
        /// </summary>
        /// <param name="stage"> Этап НИР </param>
        Task RemoveOutdatedIncludesAsync(NirStage stage);
    }
}