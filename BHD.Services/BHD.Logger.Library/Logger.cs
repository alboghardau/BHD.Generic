using BHD.Logger.Enums;
using BHD.Logger.Library.Core;
using BHD.Logger.Models;
using System;
namespace BHD.Loggers
{
	public class Logger
    {
		LogsStore _logsStore;
        LoggerConfig _config;

        public Logger(LogsStore logsStore, LoggerConfig loggerConfig)
        {
            _logsStore = logsStore;
            _config = loggerConfig;
        }

        public void Verbose(string message)
		{
            if (_config.IsVerboseActive)
            {
                var log = new Log(message, LogLevel.Verbose);
                _logsStore.Add(log);
            }
		}

		public void Trace(string message)
        {
            if (_config.IsTraceActive)
            {
                var log = new Log(message, LogLevel.Verbose);
                _logsStore.Add(log);
            }
        }

		public void Info(string message)
        {
            if (_config.IsInformationActive)
            {
                var log = new Log(message, LogLevel.Verbose);
                _logsStore.Add(log);
            }
        }

		public void Warning(string message)
        {
            if (_config.IsWarningActive)
            {
                var log = new Log(message, LogLevel.Verbose);
                _logsStore.Add(log);
            }
        }

		public void Error(LogLevel logLevel, string message)
        {
            if (_config.IsErrorActive)
            {
                var log = new Log(message, LogLevel.Verbose);
                _logsStore.Add(log);
            }
        }
    }
}

