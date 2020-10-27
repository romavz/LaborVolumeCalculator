using LaborVolumeCalculator.Models.Dictionary;

namespace LaborVolumeCalculator.Data.DevLabors
{
    internal class TestsDevelopmentRateBuilder
    {
        public TestsDevelopmentRateBuilder(ComponentsMicroArchitecture componentsMicroArchitecture, TestsScale testsScale, TestsCoverageLevel testsCoverageLevel)
        {
            ComponentsMicroArchitecture = componentsMicroArchitecture;
            TestsScale = testsScale;
            TestsCoverageLevel = testsCoverageLevel;
        }

        private ComponentsMicroArchitecture ComponentsMicroArchitecture { get; set; }

        private TestsScale TestsScale { get; set; }
        private TestsCoverageLevel TestsCoverageLevel { get; set; }

        public TestsDevelopmentRate Create(double value)
        {
            return new TestsDevelopmentRate(ComponentsMicroArchitecture, TestsScale, TestsCoverageLevel, value);
        }

        public TestsDevelopmentRateBuilder WithMicroArch(ComponentsMicroArchitecture arch)
        {
            this.ComponentsMicroArchitecture = arch;
            return this;
        }

        public TestsDevelopmentRateBuilder WithTestsScale(TestsScale scale)
        {
            this.TestsScale = scale;
            return this;
        }

        public TestsDevelopmentRateBuilder WithTestsCoverLevel(TestsCoverageLevel level)
        {
            this.TestsCoverageLevel = level;
            return this;
        }

        public TestsDevelopmentRate Create(TestsCoverageLevel level, double value)
        {
            return this.WithTestsCoverLevel(level).Create(value);
        }

        public TestsDevelopmentRate Create(ComponentsMicroArchitecture arch, TestsScale scale, TestsCoverageLevel coverLevel, double value)
        {
            return this.WithMicroArch(arch).WithTestsScale(scale).WithTestsCoverLevel(coverLevel).Create(value);
        }

    }
}