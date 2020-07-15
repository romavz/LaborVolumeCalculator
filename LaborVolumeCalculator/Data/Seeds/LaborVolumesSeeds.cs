using LaborVolumeCalculator.Migrations;
using LaborVolumeCalculator.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace LaborVolumeCalculator.Data.Seeds
{
    public class LaborVolumesSeeds
    {
        public LaborVolumesSeeds(IQueryable<Labor> labors)
        {
            this.labors = labors;
            Data = new List<LaborVolume>();
            LoadNirLaborVolumes();
            LoadOkrLaborVolumes();
        }

        public IList<LaborVolume> Data { get; private set; }

        private readonly IQueryable<Labor> labors;
        private void Add(string laborCode, double min_value, double max_value)
        {
            Labor labor = GetLaborByCode(laborCode);
            Data.Add(new LaborVolume(labor, (float)min_value, (float)max_value));
        }

        private Labor GetLaborByCode(string code)
        {
            Labor result = (from labor in labors
                    where labor.Code == code
                    select labor)
                   .First();
            return result;
        }
        private void LoadNirLaborVolumes()
        {
            Add("1.1", 0.5, 1.5);
            Add("1.2", 0.5, 0.6);
            Add("1.3", 0.1, 0.2);
            Add("1.4", 0.2, 1.0);
            Add("1.5", 1.5, 2.2);
            Add("1.6", 0.2, 1.0);
            Add("1.7", 0.2, 1.0);
            Add("1.9", 0.02, 0.05);
            Add("1.11", 0.5, 1.5);
            Add("1.13", 1.5, 5.0);
            Add("1.15", 0.2, 0.5);
            Add("1.16", 0.1, 1.5);
            Add("1.17", 0.3, 0.6);
            Add("1.18", 0.5, 1.0);
            Add("1.19", 1.0, 2.5);
            Add("1.20", 0.01, 0.02);
            Add("1.21", 0.5, 1.5);
            Add("1.22", 0.02, 0.08);
            Add("1.24", 0.01, 0.02);
            Add("1.25", 0.02, 0.03);
            Add("1.26", 0.01, 0.02);
            Add("1.27", 0.1, 0.2);
            Add("1.28", 0.1, 0.25);
            Add("1.29", 0.01, 0.05);
        }

        private void LoadOkrLaborVolumes()
        {
            Add("2.1.1", 0.1, 0.25);
            Add("2.1.2", 0.5, 1.5);
            Add("2.1.3", 0.5, 2.5);

            Add("2.2.1", 0.1, 0.25);
            Add("2.2.2", 0.1, 0.35);
            Add("2.2.3", 0.1, 0.25);

            Add("2.3.3", 0.5, 1.5);
            Add("2.3.4", 0.1, 0.3);
            Add("2.3.5", 0.1, 0.3);
            Add("2.3.6", 0.05, 0.15);

            Add("2.4.1", 0.5, 10.0);
            Add("2.4.4", 0.2, 2.0);

            Add("2.5.1", 0.5, 1.5);
            Add("2.5.2", 0.15, 0.3);

            Add("2.6.2", 0.5, 1.2);
            Add("2.6.3", 0.2, 2.0);

            Add("2.7.1", 0.5, 2.0);
            Add("2.7.2", 0.01, 0.02);
            Add("2.7.3", 0.1, 0.2);
            Add("2.7.4", 0.1, 0.2);
            Add("2.7.5", 0.1, 0.25);
        }

    }
}
