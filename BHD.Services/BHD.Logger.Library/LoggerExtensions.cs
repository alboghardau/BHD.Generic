using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BHD.Logger.Library.Writers;
using Microsoft.Extensions.Configuration;

namespace BHD.Logger.Library
{
    public static class LoggerExtensions
    {
        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("LoggerClient");
            
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<LogsStore>();
            services.AddSingleton(new LoggerConfig(configuration));
            services.AddSingleton<IConsoleWriter, ConsoleWriter>();
            services.AddTransient<HttpWriter>();
        }
    }
}
