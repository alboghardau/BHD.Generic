using System;
using BHD.Logger.Interfaces;
using BHD.Logger.Models;
using BHD.Logger.Utils.Writers;
using Microsoft.AspNetCore.Mvc;

namespace BHD.Logger.Services
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

