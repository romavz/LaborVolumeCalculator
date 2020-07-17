using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Documents
{
    public class NirLaborVolumesDoc
    {
        public NirLaborVolumesDoc()
        {
        }

        public int ID { get; set; }

        public bool IsImplemented { get; set; }

        public string Number { get; set; }

        public DateTime Date { get; set; }

        public int NiokrID { get; set; }

        public Niokr Niokr { get; set; }

        public int NiokrStageID { get; set; }

        public NiokrStage NiokrStage { get; set; }
        
        public float NirInnovationRate { get; set; }

        public List<NirLaborVolumesDocRecord> NirLaborVolumesDocRecords { get; set; }

        public float Total { get; set; }
    }
}
