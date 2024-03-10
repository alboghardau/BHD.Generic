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
                case LogLevel.Verbose:
                    return ConsoleColor.White;
                case LogLevel.Information:
                    return ConsoleColor.White;
                case LogLevel.Trace:
                    return ConsoleColor.White;
                case LogLevel.Warning:
                    return ConsoleColor.DarkYellow;
                case LogLevel.Error:
                    return ConsoleColor.Red;
            }

            return ConsoleColor.White;
        }
    }
}

