using System;
using BHD.Logger.Library.Enums;

namespace BHD.Logger.Library.Models
{
	public class Log : IComparable<Log>
	{
		public DateTime Time { get; set; }
        public string Message { get; set; }
        public LogLevel LogLevel { get; set; }
        public string? ExceptionMessage { get; set; }
        public string? ExceptionStack { get; set; }
        public string? Source { get; set; }             //holds the App Name, Server Name, etc.
        public string? IpAddress { get; set; }

        public Log(string message, LogLevel logLevel)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
        }

        public Log(string message, LogLevel logLevel, Exception exception)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
            ExceptionMessage = exception.Message;
            ExceptionStack = exception.StackTrace;
        }

        public Log(string message, LogLevel logLevel, Exception exception, string source, string? ipAddress)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
            ExceptionMessage = exception.Message;
            ExceptionStack = exception.StackTrace;
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

        public int CompareTo(Log? other)
        {
            return other != null ? Time.CompareTo(other.Time) : 0;
        }
    }
}

