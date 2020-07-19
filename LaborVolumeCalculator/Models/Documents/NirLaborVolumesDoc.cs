using LaborVolumeCalculator.Models.Dictionary;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Проведен")]
        public bool IsImplemented { get; set; }
        
        [DisplayName("Номер")]
        public string Number { get; set; }
        
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        public int NirID { get; set; }

        [DisplayName("НИР")]
        public Nir Nir { get; set; }

        public int NiokrStageID { get; set; }

        [DisplayName("Этап")]
        public NiokrStage NiokrStage { get; set; }
        
        [DisplayName("Коэффициент новизны")]
        public float NirInnovationRate { get; set; }

        public List<NirLaborVolumesDocRecord> NirLaborVolumesDocRecords { get; set; }

        [DisplayName("Итого")]
        public float Total { get; set; }
    }
}
