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
            services.AddScoped<INirStageRepository, NirStageRepository>();
            services.AddScoped<INirStageLaborVolumeRepository, NirStageLaborVolumeRepository>();
            services.AddScoped<IRepository<SoftwareDevEnv>, SoftwareDevEnvRepository>();
            services.AddScoped<IRepository<NirStageSoftwareDevLaborGroup>, NirStageSoftwareDevLaborGroupRepository>();
            services.AddScoped<IRepository<NirStageOntdLaborVolume>, NirStageOntdLaborVolumeRepository>();
            return services;
        }
    }
}