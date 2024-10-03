using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Infrastructure.BLL;
using PruebaTecnica.Infrastructure.Repositories;
using PruebaTecnica.Infrastructure.Service;
namespace PruebaTecnica.Infrastructure.IOC
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPruebaTecnicaDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories(configuration);
            services.AddBussinessLogicLayer(configuration);
            services.AddService();
            return services;
        }
    }
}
