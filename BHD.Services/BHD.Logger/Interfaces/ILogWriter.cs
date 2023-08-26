using System;
using BHD.Logger.Models;

namespace BHD.Logger.Interfaces
{
	public interface ILogWriter
	{
		public void WriteLog(Log log);
	}
}

