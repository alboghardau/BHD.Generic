using BHD.Logger.Library.Core;
using BHD.Logger.Library.Enums;
using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;

namespace BHD.Logger.Library
{
    public class Logger : ILogger
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

