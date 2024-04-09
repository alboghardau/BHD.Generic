using BHD.Logger.Library.Enums;
using Microsoft.Extensions.Configuration;

namespace BHD.Logger.Library.Core
{
    public class LoggerConfig
    {
        //Log Levels parameters
        private bool IsVerboseActive { get; set; }
        private bool IsTraceActive { get; set; }
        private bool IsInformationActive { get; set; }
        private bool IsWarningActive { get; set; }
        private bool IsErrorActive { get; set; }
        private bool IsFatalActive { get; set; }
        
        //Broadcast parameters
        public bool EnableBroadcast { get; private set; }
        public int BroadcastInterval { get; private set; }
        public string? IpAddress { get; private set; }
        public string? Port { get; private set; }
        public int BulkSize { get; private set; }
        
        //Deep storage parameters
        public bool EnableDeepStorage { get; private set; }
        public int DeepStorageInterval { get; private set; }

        //Main parameters
        public bool EnableConsoleWriting { get; private set; }
        
        public LoggerConfig(IConfiguration config)
        {
            var loggerConfig = config.GetSection("Logger");
            
            //Log Levels
            IsVerboseActive = loggerConfig.GetValue("Levels:Verbose", false);
            IsTraceActive = loggerConfig.GetValue("Levels:Trace", false);
            IsInformationActive = loggerConfig.GetValue("Levels:Information", false);
            IsWarningActive = loggerConfig.GetValue("Levels:Warning", false);
            IsErrorActive = loggerConfig.GetValue("Levels:Error", false);
            IsFatalActive = loggerConfig.GetValue("Levels:Fatal", false);
            
            //Broadcast
            EnableBroadcast = loggerConfig.GetValue("Broadcast", false);
            BroadcastInterval = loggerConfig.GetValue("BroadcastInterval", 2500);
            IpAddress = loggerConfig.GetValue(("IpAddress"), "");
            Port = loggerConfig.GetValue(("Port"), "");
            BulkSize = loggerConfig.GetValue("BulkSize", 500);
            
            //Deep Storage
            EnableDeepStorage = loggerConfig.GetValue("DeepStorage", false);
            DeepStorageInterval = loggerConfig.GetValue("DeepStorageInterval", 1000);
            
            //Console
            EnableConsoleWriting = loggerConfig.GetValue("WriteToConsole", false);
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
