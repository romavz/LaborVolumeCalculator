using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.Rates
{
    public class CorrectionRatesBundleBuilder
    {
        public CorrectionRatesBundle Create(
            int number,
            string name,
            SolutionInnovationRate solutionInnovationRate,
            StandardModulesUsingRate standardModulesUsingRate,
            InfrastructureComplexityRate infrastructureComplexityRate,
            ArchitectureComplexityRate architectureComplexityRate,
            TestsDevelopmentRate testsDevelopmentRate)
        {
            return new CorrectionRatesBundle(
                number,
                name,
                solutionInnovationRate, 
                standardModulesUsingRate,
                infrastructureComplexityRate,
                architectureComplexityRate,
                testsDevelopmentRate
            );
        }

        public CorrectionRatesBundle Create(
            int number,
            string name,
            SolutionInnovationRate solutionInnovationRate,
            StandardModulesUsingRate standardModulesUsingRate,
            InfrastructureComplexityRate infrastructureComplexityRate,
            ArchitectureComplexityRate architectureComplexityRate,
            TestsDevelopmentRate testsDevelopmentRate,
            Action<CorrectionRatesBundle> addCustomValues
            )
        {

            var result = this.Create(number, name,
                solutionInnovationRate, 
                standardModulesUsingRate, 
                infrastructureComplexityRate, 
                architectureComplexityRate, 
                testsDevelopmentRate
            );

            addCustomValues(result);
            return result;
        }
    }
}