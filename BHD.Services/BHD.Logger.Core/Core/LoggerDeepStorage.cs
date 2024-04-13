using BHD.Logger.Library.Models;

namespace BHD.Logger.Library.Core;

/// <summary>
/// Class to be used only by LogsHut to store all logs from different sources
/// </summary>
public class LoggerDeepStorage
{
    private readonly SortedSet<Log> _sortedSet = new();

    public LoggerDeepStorage()
    {
        
    }

    /// <summary>
    /// Adds multiple logs to the Sorted Set
    /// </summary>
    public void AddLogs(List<Log> logs)
    {
        foreach (var log in logs)
        {
            _sortedSet.Add(log);
        }
    }

    /// <summary>
    /// Returns the last logs after a specified DateTime
    /// </summary>
    public List<Log> GetLogsAfterDateTime(DateTime requestedTime)
    {
        return _sortedSet.Where(log => log.Time > requestedTime).ToList();
    }

    public List<Log> GetLogsBatch(int skip, int take)
    {
        return _sortedSet.Skip(skip).Take(take).ToList();
    }

    public int GetCount()
    {
        return _sortedSet.Count;
    }
}