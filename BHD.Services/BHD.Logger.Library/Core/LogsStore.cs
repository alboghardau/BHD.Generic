using BHD.Logger.Interfaces;
using BHD.Logger.Models;
using BHD.Logger.Writers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger.Library.Core
{
    public class LogsStore
    {
        ConcurrentQueue<Log> logsQueue;
        ILogWriter logWriter;

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
