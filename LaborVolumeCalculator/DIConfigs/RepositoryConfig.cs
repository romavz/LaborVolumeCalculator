using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories;
using LaborVolumeCalculator.Repositories.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepositoryConfigServiceCollectionExtention
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Nir>, NirRepository>();
            services.AddScoped<IRepository<NirStage>, NirStageRepository>();
            services.AddScoped<IRepository<NirStageLaborVolume>, RepositoryBase<NirStageLaborVolume>>();
            services.AddScoped<IRepository<NirStageSoftwareDevLaborGroup>, RepositoryBase<NirStageSoftwareDevLaborGroup>>();
            services.AddScoped<IRepository<OntdLabor>, RepositoryBase<OntdLabor>>();
            services.AddScoped<IRepository<NirStageOntdLaborVolume>, RepositoryBase<NirStageOntdLaborVolume>>();
            services.AddScoped<IRepository<CorrectionRatesBundle>, CorrectionRatesBundleRepository>();
            services.AddScoped<IRepository<LaborVolumeRange>, LaborVolumeRangeRepository>();
            services.AddScoped<IRepository<RangeFeature>, RangeFeatureRepository>();
            services.AddScoped<IRepository<RangeFeatureCategory>, RangeFeatureCategoryRepository>();
            services.AddScoped<IRepository<DevelopmentLaborCategory>, DevelopmentLaborCategoryRepository>();
            services.AddScoped<IRepository<NirLabor>, RepositoryBase<NirLabor>>();
            services.AddScoped<IRepository<ArchitectureComplexityRate>, ArchitectureComplexityRateRepository>();
            services.AddScoped<IRepository<ComponentsMakroArchitecture>, RepositoryBase<ComponentsMakroArchitecture>>();
            services.AddScoped<IRepository<ComponentsMicroArchitecture>, RepositoryBase<ComponentsMicroArchitecture>>();
            services.AddScoped<IRepository<ComponentsInteractionArchitecture>, RepositoryBase<ComponentsInteractionArchitecture>>();
            services.AddScoped<IRepository<InfrastructureComplexityRate>, RepositoryBase<InfrastructureComplexityRate>>();           
            services.AddScoped<IRepository<NirInnovationRate>, NirInnovationRateRepository>();
            services.AddScoped<IRepository<NirInnovationProperty>, RepositoryBase<NirInnovationProperty>>();
            services.AddScoped<IRepository<NirScale>, RepositoryBase<NirScale>>();
            services.AddScoped<IRepository<NirSoftwareDevLaborGroup>, RepositoryBase<NirSoftwareDevLaborGroup>>();
            services.AddScoped<IRepository<SolutionInnovationRate>, RepositoryBase<SolutionInnovationRate>>();
            services.AddScoped<IRepository<StandardModulesUsingRate>, RepositoryBase<StandardModulesUsingRate>>();
            services.AddScoped<IRepository<TestsDevelopmentRate>, TestsDevelopmentRateRepository>();
            services.AddScoped<IRepository<TestsCoverageLevel>, RepositoryBase<TestsCoverageLevel>>();

            return services;
        }
    }
}