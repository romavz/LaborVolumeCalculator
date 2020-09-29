using System;
namespace LaborVolumeCalculator.DTO
{

    public class NirStageBaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int NirInnovationRateID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }

    public class NirStageChangeDto : NirStageBaseDto
    {
        public int ID { get; set; }
        public double NirInnovationRateValue { get; set; }
    }

    public class NirStageDto : NirStageChangeDto
    {
        public double Volume { get; set; }
    }

    public class NirStageCreateDto : NirStageBaseDto
    {
        public int NirID { get; set; }
    }
}