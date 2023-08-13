using System;
using BHD.LogsHut.Models;

namespace BHD.LogsHut.Interfaces
{
	public interface ILogGenerator
	{
		public Log GetRandomLog();
    }
}

