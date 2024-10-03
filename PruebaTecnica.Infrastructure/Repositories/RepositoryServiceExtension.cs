using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Core.Interfaces.DataContext;
using PruebaTecnica.Core.Interfaces.Repository;
using PruebaTecnica.Infrastructure.DataContext;

namespace PruebaTecnica.Infrastructure.Repositories
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton(configuration);
            services.AddTransient<IPruebaTecnicaContext,PruebaTecnicaContext>();
            services.AddTransient<IBalanceRepository, BalanceRepository>();
            services.AddTransient<IManagersRepository,ManagersRepository>();
            services.AddTransient<IBalanceManagersAssignmentRepository, BalanceManagersAssignmentRepository>();
            return services;
        }
    }
}
