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

        public string App { get; set; }
        public string Message { get; set; }

        public Log(LogLevel logLevel, string appLevel, string message)
        {
            this.LogLevel = logLevel;
            this.App = appLevel;
            this.Message = message;
        }

        public override string ToString()
        {
            return Time.ToString() + " - " + LogLevel.ToString() + " - " + Message;
        }
    }
}
