using BHD.Logger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger.DeepCore.Statistics.Counters
{
    public class LogsPerMinute
    {
        private Dictionary<DateTime, int> logsPerMinute = new();

        public void CountLogs(List<Log> logs)
        {
            foreach (var log in logs)
            {
                var time = log.Time;
                var logMinute = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);

                if(logsPerMinute.ContainsKey(logMinute))                
                    logsPerMinute[logMinute]++;
                else
                    logsPerMinute[logMinute] = 1;                
            }
        }

        public Dictionary<DateTime, int> GetLastHour()
        {
            var logsCountLastHour = new Dictionary<DateTime, int>();
            var currentMinute = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, 0);

            for (int i = 0; i < 60; i++)
            {                
                var minuteToCheck = currentMinute.AddMinutes(-i);
                logsCountLastHour[minuteToCheck] = GetLogsCountPerMinute(minuteToCheck);
            }

            return logsCountLastHour;
        }

        public int GetTotalCountForLastHour()
        {
            var logsCount = 0;
            var currentMinute = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);

            for (int i = 0; i < 60; i++)
            {
                var minuteToCheck = currentMinute.AddMinutes(-i);
                logsCount += GetLogsCountPerMinute(minuteToCheck);
            }

            return logsCount;
        }

        private int GetLogsCountPerMinute(DateTime minute)
        {
            if (logsPerMinute.ContainsKey(minute))
                return logsPerMinute[minute];
            else
                return 0;
        }
    }
}
