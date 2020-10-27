using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Nir
{
    internal class NirStageDefaultLaborsBuilder
    {
        private StageForNir _nirStage;
        public NirStageDefaultLaborsBuilder(StageForNir stage)
        {
            this._nirStage = stage;
        }

        public NirStageDefaultLaborsBuilder WithStage(StageForNir stage) {
            _nirStage = stage;
            return this;
        }

        public NirStageDefaultLabor Create(NirLabor labor) 
        {
            return new NirStageDefaultLabor(_nirStage, labor);
        }
    }
}