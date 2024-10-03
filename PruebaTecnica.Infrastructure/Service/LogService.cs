using Microsoft.Extensions.Configuration;
using PruebaTecnica.Core.Interfaces.Service;

namespace PruebaTecnica.Infrastructure.Service
{
    public class LogService(IConfiguration configuration) : ILogService
    {
        private readonly IConfiguration _configuration = configuration;
        public void message(string message)
        {
            var route = _configuration["logRoute"];
            var directoryRoute = Path.GetDirectoryName(route);
            var fileName = Path.GetFileName(route);
            var combinepath = Path.Combine(directoryRoute, fileName);
            if (!Directory.Exists(combinepath))
            {
                Directory.CreateDirectory(directoryRoute);
            }
            using (StreamWriter writer = new StreamWriter(combinepath, true))
            {
                writer.WriteLine($"[{DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss")}] : {message}");
            }
        }
    }
}
