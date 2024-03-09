using System;
using BHD.Logger.Enums;

namespace BHD.Logger.Models
{
	public class Log
	{
		public DateTime Time { get; set; }
        public String? Message { get; set; }
        public LogLevels LogLevel { get; set; }
        public Exception? Exception { get; set; }
        //holds the App Name, Server Name, etc.
        public String? Source { get; set; }
        public String? IpAdress { get; set; }

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

