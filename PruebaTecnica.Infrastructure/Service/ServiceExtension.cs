using Microsoft.Extensions.DependencyInjection;
using PruebaTecnica.Core.Interfaces.Service;

namespace PruebaTecnica.Infrastructure.Service
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services) 
        {
            services.AddTransient<IExecuteStoredProcedureService, ExecuteStoredProcedureService>();
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<ISqlCommandService,SqlCommandService>();
            return services;


        }
    }
}
