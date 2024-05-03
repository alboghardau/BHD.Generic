using BHD.Logger.DeepCore.Statistics;
using BHD.Logger.DeepCore.Statistics.Counters;
using BHD.Logger.DeepCore.Storage;
using BHD.Logger.Library;
using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Writers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BHD.Logger.DeepCore
{
    public static class DeepServiceExtensions
    {
        public static void AddDeepLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogger, Loggy>();
            services.AddSingleton<IBuffer, DeepBuffer>();
            services.AddSingleton<DeepStorage>();
            services.AddSingleton(new LoggerConfig(configuration));
            services.AddSingleton<ConsoleWriter>();

            //statistics
            services.AddSingleton<StatisticsManager>();
            services.AddSingleton<LogsPerMinute>();
            services.AddSingleton<GeneralCounters>();
        }
    }
}
