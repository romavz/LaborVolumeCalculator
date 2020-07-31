using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Models.Documents
{
    public class NirLaborVolumesDocRecord
    {
        public NirLaborVolumesDocRecord()
        {
        }

        public NirLaborVolumesDocRecord(NirLaborVolumesDoc doc, Labor labor) : this()
        {
            NirLaborVolumesDoc = doc ?? throw new ArgumentNullException("doc");
            NirLaborVolumesDocID = doc.ID;

            Labor = labor ?? throw new ArgumentNullException("labor");
            LaborID = labor.ID;
        }

        public int ID { get; set; }
        public int NirLaborVolumesDocID { get; set; }

        [DisplayName("Документ учета трудозатрат")]
        public NirLaborVolumesDoc NirLaborVolumesDoc { get; set; }

        public int LaborID { get; set; }

        [DisplayName("Работа")]
        public Labor Labor { get; set; }
        
        [DisplayName("Объем")]
        public float Volume { get; set; }

        [DisplayName("С учетом коэффицинтов")]
        public float Calculation { get; set; }
    }
}
