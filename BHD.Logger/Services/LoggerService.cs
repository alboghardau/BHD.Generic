using System;
using System.Collections.Generic;
using System.Linq;
using BHD.Logger.Enums;
using BHD.Logger.Interfaces;
using BHD.Logger.Models;

namespace BHD.Logger.Services
{
    public class LoggerService : ILoggerService
    {
        private List<Log> logList;
        private LogConfig _logConfig;

        public LoggerService(LogConfig logConfig)
        {
            logList = new List<Log>();
            _logConfig = logConfig;
        }

        public void AddLog(Log log)
        {
            if (_logConfig.IsLogLevelActive(log.LogLevel))
            {
                logList.Add(log);
            }            
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