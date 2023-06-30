using System;
using BHD.Logger.Models;

namespace BHD.Logger.Interfaces
{
	public interface ILogGenerator
	{
		public Log GetRandomLog();
    }
}

