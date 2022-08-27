using BHD.Logger.Enums;
using BHD.Logger.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger
{
    public static class Log
    {
        public static event EventHandler<LogEventArgs> LogEvent;

        /// <summary>
        /// Trigger log event
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="appLevel"></param>
        /// <param name="message"></param>
        private static void AddLog(LogLevel logLevel, AppLevel appLevel, string message)
        {
            LogEvent(null, new LogEventArgs(logLevel, appLevel, message));
        }

        /// <summary>
        /// Log Informational
        /// </summary>
        /// <param name="message">Message to display</param>
        public static void Info(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Informational, appLevel, message);
        }

        /// <summary>
        /// Log Warning
        /// </summary>
        /// <param name="message"></param>

        public static void Warn(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Warning, appLevel, message);
        }

        /// <summary>
        /// Log Error
        /// </summary>
        /// <param name="message"></param>

        public static void Error(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Error, appLevel, message);
        }

        /// <summary>
        /// Log Trace
        /// </summary>
        /// <param name="message"></param>

        public static void Trace(AppLevel appLevel, string message)
        {
            AddLog(LogLevel.Trace, appLevel, message);
        }

    }
}
