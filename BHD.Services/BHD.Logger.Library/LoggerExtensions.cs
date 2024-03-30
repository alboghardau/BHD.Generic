using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger.Library
{
    public static class LoggerExtensions
    {
        public static void AddLogger(this IServiceCollection services){
            services.AddSingleton<ILogger, Logger>();
            services.AddSingleton<LogsStore>();
            services.AddSingleton<LoggerConfig>();
        }
    }
}
