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
            return services;
        }
    }
}