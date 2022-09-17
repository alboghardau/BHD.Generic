using System;
using System.Collections.Generic;
using System.Linq;
using BHD.Logger.Enums;
using BHD.Logger.Models;

namespace BHD.Logger.Services
{
    public class LoggerService
    {
        private List<Log> logList;

        public LoggerService(List<Log> logList)
        {
            this.logList = logList;
        }

        public void AddLog(Log log)
        {
            logList.Add(log);
        }

        public void ClearLogs()
        {
            logList.Clear();
        }

        public List<Log> GetLogsAsList()
        {
            return logList;
        }
        
        public List<Log> GetLogsByLevel(LogLevel logLevel)
        {
            return logList.Where(log => log.LogLevel == logLevel).ToList();
        }

        public List<Log> GetLogsHigherLevel(LogLevel logLevel)
        {
            return logList.Where(log => log.LogLevel >= logLevel).ToList();
        }
    }
}