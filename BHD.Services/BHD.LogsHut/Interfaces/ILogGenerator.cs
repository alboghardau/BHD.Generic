using System;
using BHD.Logger.Models;

namespace BHD.LogsHut.Interfaces
{
	public interface ILogGenerator
	{
		public Log GetRandomLog();
    }
}

