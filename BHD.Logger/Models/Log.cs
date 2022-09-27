using BHD.Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHD.Logger.Models
{
    public class Log
    {
        public DateTime Time
        {
            get
            {
                return DateTime.Now.ToUniversalTime();
            }
        }

        public string ServerName { get; set; }
        public LogLevel LogLevel { get; set; }

        public AppLevel AppLevel { get; set; }
        public string Message { get; set; }

        public Log(LogLevel logLevel, AppLevel appLevel, string message)
        {
            this.LogLevel = logLevel;
            this.AppLevel = appLevel;
            this.Message = message;
        }

        public Log(LogLevel logLevel, AppLevel appLevel, string message, string serverName)
        {
            this.LogLevel = logLevel;
            this.AppLevel = appLevel;
            this.Message = message;
            this.ServerName = serverName;
        }

        public override string ToString()
        {
            return Time.ToString() + " - " + LogLevel.ToString() + " - " + Message;
        }
    }
}
