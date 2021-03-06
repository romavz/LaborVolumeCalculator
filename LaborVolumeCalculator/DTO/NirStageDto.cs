using System.Runtime.InteropServices.ComTypes;
using System;
using System.Collections.Generic;

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

    public class NirStageDeleteDto : NirStageBaseDto
    {
        public int ID { get; set; }
        public int NirID { get; set; }
        public double NirInnovationRateValue { get; set; }
        public double Volume { get; set; }
    }

    public class NirStageCreateDto : NirStageBaseDto
    {
        public int NirID { get; set; }
        public List<StageLaborVolumeDto_ListItem> LaborVolumes { get; set; }
        public List<StageSoftwareDevLaborGroupCreateDto> SoftwareDevLaborGroups { get; set; }

        public List<StageLaborVolumeDto_ListItem> OntdLaborVolumes { get; set; }
        public double Volume { get; set; }
    }

    public class NirStageChangeDto : NirStageCreateDto
    {
        public int ID { get; set; }
    }

    public class NirStageDto : NirStageBaseDto
    {
        public int ID { get; set; }
        public double NirInnovationRateValue { get; set; }
        public double Volume { get; set; }
        public List<StageLaborVolumeDto> LaborVolumes { get; set; }
        public List<StageSoftwareDevLaborGroupDto> SoftwareDevLaborGroups { get; set; }
        public List<StageLaborVolumeDto> OntdLaborVolumes { get; set; }
    }
}