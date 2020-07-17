using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public NirLaborVolumesDoc NirLaborVolumesDoc { get; set; }

        public int LaborID { get; set; }

        public Labor Labor { get; set; }
        
        public float Volume { get; set; }

        public float Calculation { get; set; }
    }
}
