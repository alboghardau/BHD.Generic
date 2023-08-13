using System;
using BHD.LogsHut.Interfaces;
using BHD.LogsHut.Models;
using BHD.LogsHut.Utils.Writers;
using Microsoft.AspNetCore.Mvc;

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

