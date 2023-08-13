using System;
using BHD.LogsHut.Models;

namespace BHD.LogsHut.Interfaces
{
	public interface ILogWriter
	{
		public void WriteLog(Log log);
	}
}

