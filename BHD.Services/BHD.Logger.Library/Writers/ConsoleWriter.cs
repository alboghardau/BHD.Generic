using System;
using BHD.Logger.Enums;
using BHD.Logger.Interfaces;
using BHD.Logger.Models;

namespace BHD.Logger.Writers
{
	public class ConsoleWriter : ILogWriter
	{
        public void WriteLog(Log log)
        {
            Console.ForegroundColor = GetColor(log);
            Console.WriteLine(log.GetFormatedShort());
            Console.ResetColor();
        }

        private ConsoleColor GetColor(Log log)
        {
            switch(log.LogLevel)
            {
                case LogLevels.Verbose:
                    return ConsoleColor.White;
                case LogLevels.Info:
                    return ConsoleColor.White;
                case LogLevels.Trace:
                    return ConsoleColor.White;
                case LogLevels.Warning:
                    return ConsoleColor.DarkYellow;
                case LogLevels.Error:
                    return ConsoleColor.Red;
            }

            return ConsoleColor.White;
        }
    }
}

