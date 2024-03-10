using BHD.Logger.Library.Enums;
using Microsoft.Extensions.Configuration;

namespace BHD.Logger.Library.Core
{
    public class LoggerConfig
    {
        //LogLevels activation
        public bool IsVerboseActive { get; private set; }
        public bool IsTraceActive { get; private set; }
        public bool IsInformationActive { get; private set; }
        public bool IsWarningActive { get; private set; }
        public bool IsErrorActive { get; private set; }
        public bool IsFatalActive { get; private set; }
        public bool ShouldWriteToConsole { get; private set; }

        public void InitConfig(IConfiguration config)
        {
            if (config != null)
            {
                IsVerboseActive = config.GetValue("Logging:Verbose", false);
                IsTraceActive = config.GetValue("Logging:Trace", false);
                IsInformationActive = config.GetValue("Logging:Information", false);
                IsWarningActive = config.GetValue("Logging:Warning", false);
                IsErrorActive = config.GetValue("Logging:Error", false);
                IsFatalActive = config.GetValue("Logging:Fatal", false);
                ShouldWriteToConsole = config.GetValue("Logging.WriteToConsole", false);
            }
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
