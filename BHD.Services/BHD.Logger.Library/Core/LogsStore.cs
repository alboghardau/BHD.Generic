using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using BHD.Logger.Library.Writers;
using System.Collections.Concurrent;

namespace BHD.Logger.Library.Core
{
    public class LogsStore
    {
        private readonly LoggerConfig _loggerConfig;
        private readonly ConcurrentQueue<Log> _logsQueue = new ConcurrentQueue<Log>();
        private readonly IConsoleWriter _consoleWriter;

        public LogsStore(LoggerConfig loggerConfig)
        {
            _consoleWriter = new ConsoleWriter();
            _loggerConfig = loggerConfig;
        }

        public void Add(Log log)
        {
            if(_loggerConfig.ShouldWriteToConsole)
                _consoleWriter.WriteLog(log);
            
            _logsQueue.Enqueue(log);
        }

        public void Clear()
        {
            _logsQueue.Clear();
        }

        public List<Log> GetLogs()
        {
            return _logsQueue.ToList();
        }
    }
}
