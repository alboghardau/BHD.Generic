using BHD.Logger.Enums;
using BHD.Logger.Interfaces;
using BHD.Logger.Models;
using BHD.Logger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger
{
    public class Logger
    {
        private static readonly Lazy<Logger> logger = new Lazy<Logger>(() => new Logger());

        public static Logger Instance
        {
            get
            {
                return logger.Value;
            }
        }

        private ILoggerService loggerService;
        private LogConfig logConfig;

        private Logger()
        {
            this.logConfig = new LogConfig();

            this.loggerService = new LoggerService(this.logConfig);
        }

        /// <summary>
        /// Log Informational
        /// </summary>
        /// <param name="message">Message to display</param>
        public void Info(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Informational, appLevel, message);
        }

        /// <summary>
        /// Log Warning
        /// </summary>
        /// <param name="message"></param>
        public void Warn(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Warning, appLevel, message);
        }

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="message"></param>
        public void Error(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Error, appLevel, message);
        }

        /// <summary>
        /// Log Trace
        /// </summary>
        /// <param name="message"></param>
        public void Trace(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Trace, appLevel, message);
        }

        private void AddLog(LogLevel logLevel, AppLevel appLevel, string message)
        {
            this.loggerService.AddLog(new Log(logLevel, appLevel, message));
        }
    }
}
