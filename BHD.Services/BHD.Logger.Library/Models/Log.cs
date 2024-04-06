using System;
using BHD.Logger.Library.Enums;

namespace BHD.Logger.Library.Models
{
	public class Log
	{
		public DateTime Time { get; set; }
        public string? Message { get; set; }
        public LogLevel LogLevel { get; set; }
        public Exception? Exception { get; set; }
        public string? Source { get; set; }             //holds the App Name, Server Name, etc.
        public string? IpAddress { get; set; }

        public Log(string message, LogLevel logLevel)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
        }

        public Log(string? message, LogLevel logLevel, Exception? exception)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
            Exception = exception;
        }

        public Log(string? message, LogLevel logLevel, Exception? exception, string? source, string? ipAddress)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
            Exception = exception;
            Source = source;
            IpAddress = ipAddress;
        }

        public Log()
        {
        }

        public string GetFormattedShort()
        {
            return String.Format("### {0} ###" +
                " {1} |" +
                " {2} |" ,
				this.Time.ToLocalTime(),
				this.Source,
				this.Message);
        }
    }
}

