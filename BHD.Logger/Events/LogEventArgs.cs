using BHD.Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHD.Logger.Events
{
    public class LogEventArgs : EventArgs
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

        public LogEventArgs(LogLevel logLevel, AppLevel appLevel, string message)
        {
            this.LogLevel = logLevel;
            this.AppLevel = appLevel;
            this.Message = message;
        }

        public override string ToString()
        {
            return Time.ToString() + " - " + LogLevel.ToString() + " - " + Message;
        }
    }
}
