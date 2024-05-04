using BHD.Logger.DeepCore.Statistics;
using BHD.Logger.Library.Enums;
using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore.Storage;

/// <summary>
/// Class to be used only by LogsHut to store all logs from different sources
/// </summary>
public class DeepStorage
{
    public SortedSet<Log> Logs { get { return _sortedSet; } }
    public int LogsCount { get { return _sortedSet.Count(); } }

    private readonly SortedSet<Log> _sortedSet = new();

    private readonly StatisticsManager _statisticsManager;

    public DeepStorage(StatisticsManager statisticsManager)
    {
        _statisticsManager = statisticsManager;
    }

    /// <summary>
    /// Adds multiple logs to the Sorted Set
    /// </summary>
    public void AddLogs(List<Log> logs)
    {
        lock (_sortedSet)
        {
            foreach (var log in logs)
            {
                _sortedSet.Add(log);
            }
        }

        _statisticsManager.CalculateStatistics(logs);
    }
}