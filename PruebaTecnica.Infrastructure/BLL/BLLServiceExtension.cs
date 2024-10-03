using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Core.Interfaces.BLL;

namespace PruebaTecnica.Infrastructure.BLL
{
    public static class BLLServiceExtension
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IBalanceBLL, BalanceBLL>();
            services.AddTransient<IManagersBLL, ManagerBLL>();
            services.AddTransient<IBalanceManagersAssignmentBLL, BalanceManagersAssignmentBLL>();
            return services;
        }
    }
}
