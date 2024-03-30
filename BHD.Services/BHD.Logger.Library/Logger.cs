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

        public void Verbose(string message) => RecordLog(LogLevel.Verbose, message);
        public void Verbose(string format, params object[] args) => RecordLog(LogLevel.Verbose, format, args);
        public void Trace(string message) => RecordLog(LogLevel.Trace, message);
        public void Trace(string format, params object[] args) => RecordLog(LogLevel.Trace, format, args);
        public void Information(string message) => RecordLog(LogLevel.Information, message);
        public void Information(string format, params object[] args) => RecordLog(LogLevel.Information, format, args);
        public void Warning(string message) => RecordLog(LogLevel.Warning, message);
        public void Warning(string format, params object[] args) => RecordLog(LogLevel.Warning, format, args);
        public void Error(string message) => RecordLog(LogLevel.Error, message);
        public void Error(string format, params object[] args) => RecordLog(LogLevel.Error, format, args);
        public void Fatal(string message) => RecordLog(LogLevel.Fatal, message);
        public void Fatal(string format, params object[] args) => RecordLog(LogLevel.Fatal, format, args);

        public void Add(Log log)
        {
            _logsStore.Add(log);
        }

        private void RecordLog(LogLevel logLevel, string message)
        {
            if (_config.IsLogLevelActive(logLevel)){
                var log = new Log(message, logLevel);
                _logsStore.Add(log);
            }
        }
        private void RecordLog(LogLevel logLevel, string format, params object[] args)
        {
            if (_config.IsLogLevelActive(logLevel))
            {
                var message = string.Format(format, args);
                var log = new Log(message, logLevel);
                _logsStore.Add(log);
            }
        }
    }
}

