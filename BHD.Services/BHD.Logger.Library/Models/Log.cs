using System;
using BHD.Logger.Library.Enums;

namespace BHD.Logger.Library.Models
{
	public class Log
	{
		public DateTime Time { get; set; }
        public String? Message { get; set; }
        public LogLevel LogLevel { get; set; }
        public Exception? Exception { get; set; }
        public String? Source { get; set; }             //holds the App Name, Server Name, etc.
        public String? IpAdress { get; set; }

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

        public Log(string? message, LogLevel logLevel, Exception? exception, string? source, string? ipAdress)
        {
            Time = DateTime.UtcNow;
            Message = message;
            LogLevel = logLevel;
            Exception = exception;
            Source = source;
            IpAdress = ipAdress;
        }

        public Log()
        {
        }

        public string GetFormatedShort()
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

