using System;
using BHD.LogsHut.Enums;

namespace BHD.LogsHut.Models
{
	public class Log
	{
		public DateTime Time { get; set; }
		public LogLevels LogLevel { get; set; }
		public String Service { get; set; }
		public String Message { get; set; }
		public String MethodName { get; set; }
		public String IpAdress { get; set; }
		public String User { get; set; }
		public String CallStack { get; set; }

        public string GetFormatedShort()
        {
            return String.Format("### {0} ###" +
                " {1} |" +
                " {2} |" ,
				this.Time.ToLocalTime(),
				this.Service,
				this.Message);
        }
    }
}

