using System;
using System.Collections.Concurrent;
using BHD.Logger.Models;

namespace BHD.LogsHut.Services
{
	public class LoggerService
    {
        private ConcurrentQueue<Log> _logs;

		private WriterService _writerService;

        public LoggerService(WriterService writerService)
		{
			_logs = new ConcurrentQueue<Log>();
			_writerService = writerService;
		}

		public void AddLog(Log singleLog)
		{
			_logs.Enqueue(singleLog);
			_writerService.Write(singleLog);
		}

		public void ClearLogs()
		{
			_logs.Clear();
		}

		public List<Log> GetAllLogs()
		{
			return _logs.ToList<Log>();
		}

		public long GetLogsNumber()
		{
			return _logs.Count();
		}

		public List<Log> GetLogsAfterTime(DateTime time)
		{
			List<Log> timeFilteredLogs = _logs.Where(log => log.Time > time).ToList();
			return timeFilteredLogs;
		}
	}
}

