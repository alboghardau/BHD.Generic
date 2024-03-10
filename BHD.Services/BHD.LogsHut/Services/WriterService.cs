using System;
using BHD.Logger.Models;
using BHD.Logger.Interfaces;

namespace BHD.LogsHut.Services
{
	public class WriterService
	{
		//Writers
		private ILogWriter consoleWriter;

		public WriterService(ILogWriter consoleWriter)
		{
			this.consoleWriter = consoleWriter;
		}

		public void Write(Log log)
		{
			this.consoleWriter.WriteLog(log);
		}
	}
}

