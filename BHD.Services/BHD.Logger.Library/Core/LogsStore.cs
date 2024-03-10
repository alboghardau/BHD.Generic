using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using BHD.Logger.Library.Writers;
using System.Collections.Concurrent;

namespace BHD.Logger.Library.Core
{
    public class LogsStore
    {
        private ConcurrentQueue<Log> logsQueue;
        private readonly ILogWriter logWriter;

        public LogsStore()
        {
            logsQueue = new ConcurrentQueue<Log>();
            logWriter = new ConsoleWriter();
        }

        public void Add(Log log)
        {
            logWriter.WriteLog(log);
            logsQueue.Enqueue(log);
        }

        public void Clear()
        {
            logsQueue.Clear();
        }

        public List<Log> GetLogs()
        {
            return logsQueue.ToList();
        }
    }
}
