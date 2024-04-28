using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BHD.Logger.Library.Writers;
using Microsoft.Extensions.Configuration;

namespace BHD.Logger.Library
{
    public static class LoggerServiceExtensions
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("LoggerClient");
            
            services.AddSingleton<ILogger, Loggy>();
            services.AddSingleton<IBuffer, LogsBuffer>();
            services.AddSingleton(new LoggerConfig(configuration));
            services.AddSingleton<ConsoleWriter>();
            services.AddTransient<HttpWriter>();
        }
    }
}
