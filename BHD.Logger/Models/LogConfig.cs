using System;
namespace BHD.Logger.Models
{
    public class LogConfig
    {
        public bool LogTrace { get; set; } = true;
        public bool LogInfo { get; set; } = true;
        public bool LogWarning { get; set; } = true;
        public bool LogError { get; set; } = true;

        public LogConfig()
        {
            
        }
    }
}

