using BHD.Logger.Library.Enums;
using Microsoft.Extensions.Configuration;

namespace BHD.Logger.Library.Core
{
    public class LoggerConfig
    {
        //LogLevels activation
        private bool IsVerboseActive { get; set; }
        private bool IsTraceActive { get; set; }
        private bool IsInformationActive { get; set; }
        private bool IsWarningActive { get; set; }
        private bool IsErrorActive { get; set; }
        private bool IsFatalActive { get; set; }
        public bool ShouldWriteToConsole { get; private set; }
        public bool ShouldWriteToServer { get; private set; }
        public string? IpAddress { get; private set; }
        public string? Port { get; private set; }

        public LoggerConfig(IConfiguration config)
        {
            var loggerConfig = config.GetSection("Logger");
            
            IsVerboseActive = loggerConfig.GetValue("Levels:Verbose", false);
            IsTraceActive = loggerConfig.GetValue("Levels:Trace", false);
            IsInformationActive = loggerConfig.GetValue("Levels:Information", false);
            IsWarningActive = loggerConfig.GetValue("Levels:Warning", false);
            IsErrorActive = loggerConfig.GetValue("Levels:Error", false);
            IsFatalActive = loggerConfig.GetValue("Levels:Fatal", false);
            ShouldWriteToConsole = loggerConfig.GetValue("WriteToConsole", false);
            ShouldWriteToServer = loggerConfig.GetValue("WriteToServer", false);
            IpAddress = loggerConfig.GetValue(("IpAddress"), "");
            Port = loggerConfig.GetValue(("Port"), "");
        }

        public bool IsLogLevelActive(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Verbose => IsVerboseActive,
                LogLevel.Trace => IsTraceActive,
                LogLevel.Information => IsInformationActive,
                LogLevel.Warning => IsWarningActive,
                LogLevel.Error => IsErrorActive,
                LogLevel.Fatal => IsFatalActive,
                _ => false // Log level not supported or unknown
            };
        }
    }
}
