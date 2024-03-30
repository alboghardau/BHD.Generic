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
                IsVerboseActive = config.GetValue("Logger:Verbose", false);
                IsTraceActive = config.GetValue("Logger:Trace", false);
                IsInformationActive = config.GetValue("Logger:Information", false);
                IsWarningActive = config.GetValue("Logger:Warning", false);
                IsErrorActive = config.GetValue("Logger:Error", false);
                IsFatalActive = config.GetValue("Logger:Fatal", false);
                ShouldWriteToConsole = config.GetValue("Logger.WriteToConsole", false);
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
