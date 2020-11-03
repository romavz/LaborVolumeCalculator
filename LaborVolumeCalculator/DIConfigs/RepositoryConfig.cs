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
            services.AddScoped<IRepository<NirStage>, NirStageRepository>();
            services.AddScoped<IRepository<NirStageLaborVolume>, RepositoryBase<NirStageLaborVolume>>();
            services.AddScoped<IRepository<SoftwareDevEnv>, SoftwareDevEnvRepository>();
            services.AddScoped<IRepository<NirStageSoftwareDevLaborGroup>, RepositoryBase<NirStageSoftwareDevLaborGroup>>();
            services.AddScoped<IRepository<OntdLabor>, RepositoryBase<OntdLabor>>();
            services.AddScoped<IRepository<NirStageOntdLaborVolume>, RepositoryBase<NirStageOntdLaborVolume>>();
            services.AddScoped<IRepository<CorrectionRatesBundle>, CorrectionRatesBundleRepository>();
            services.AddScoped<IRepository<DbDevLabor>, DbDevLaborRepository>();
            services.AddScoped<IRepository<DbEntityCountRange>, RepositoryBase<DbEntityCountRange>>();
            return services;
        }
    }
}