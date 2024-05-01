using BHD.Logger.DeepCore.Statistics.Counters;
using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore.Statistics
{
    public class StatisticsManager
    {

        private readonly LogsPerMinute _logsPerMinute;

        public StatisticsManager(LogsPerMinute logsPerMinute)
        {
            _logsPerMinute = logsPerMinute;
        }

        public void CountLogs(List<Log> logs)
        {
            _logsPerMinute.CountLogs(logs);
        }

        public Dictionary<DateTime, int> GetLastHourPerMinute()
        {
            return _logsPerMinute.GetLastHour();
        }
    }
}
