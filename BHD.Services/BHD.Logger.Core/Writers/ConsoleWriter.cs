using BHD.Logger.Library.Enums;
using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;

namespace BHD.Logger.Library.Writers
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void WriteLog(Log log)
        {
            Console.ForegroundColor = GetColor(log);
            Console.WriteLine(log.GetFormattedShort());
            Console.ResetColor();
        }

        private ConsoleColor GetColor(Log log)
        {
            return log.LogLevel switch
            {
                LogLevel.Verbose => ConsoleColor.White,
                LogLevel.Information => ConsoleColor.White,
                LogLevel.Trace => ConsoleColor.White,
                LogLevel.Warning => ConsoleColor.DarkYellow,
                LogLevel.Error => ConsoleColor.Red,
                _ => ConsoleColor.White
            };
        }
    }
}

