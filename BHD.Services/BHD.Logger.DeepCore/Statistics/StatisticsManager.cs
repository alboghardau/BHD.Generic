using BHD.Logger.DeepCore.Statistics.Counters;
using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore.Statistics
{
    public class StatisticsManager
    {
        private readonly GeneralCounters _generalCounters;
        private readonly LogsPerMinute _logsPerMinute;

        public StatisticsManager(LogsPerMinute logsPerMinute, GeneralCounters generalCounters)
        {
            _logsPerMinute = logsPerMinute;
            _generalCounters = generalCounters;
        }

        public void CalculateStatistics(List<Log> logs)
        {
            _generalCounters.CalculateStatistics(logs);
            _logsPerMinute.CalculateStatistics(logs);
        }

        public Dictionary<DateTime, int> GetLastHourPerMinute()
        {
            return _logsPerMinute.GetLastHour();
        }

        public long GetTotalCount()
        {
            return _generalCounters.TotalLogsCount;
        }

        public long GetFatalCount()
        {
            return _generalCounters.TotalFatalCount;
        }

        public long GetErrorCount()
        {
            return _generalCounters.TotalErrorCount;
        }
    }
}
