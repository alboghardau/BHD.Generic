using System;
using BHD.Logger.Enums;

namespace BHD.Logger.Models
{
    public class LogConfig
    {
        public bool LogTrace { get; set; } = true;
        public bool LogInfo { get; set; } = true;
        public bool LogWarning { get; set; } = true;
        public bool LogError { get; set; } = true;

        public bool WriteToFile { get; set; } = false;
        public bool WriteToConsole { get; set; } = false;

        public LogConfig()
        {
            
        }

        public bool IsLogLevelActive(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return LogTrace;
                case LogLevel.Informational:
                    return LogInfo;
                case LogLevel.Warning:
                    return LogWarning;
                case LogLevel.Error:
                    return LogError;
                default: return false;
            }            
        }
    }
}

