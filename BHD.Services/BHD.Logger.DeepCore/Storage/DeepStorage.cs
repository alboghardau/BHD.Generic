using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore.Storage;

/// <summary>
/// Class to be used only by LogsHut to store all logs from different sources
/// </summary>
public class DeepStorage
{
    private readonly SortedSet<Log> _sortedSet = new();

    public DeepStorage()
    {

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
    }

    /// <summary>
    /// Returns the last logs after a specified DateTime
    /// </summary>
    public List<Log> GetLogsAfterDateTime(DateTime requestedTime, bool isFirstCall = false)
    {
        lock (_sortedSet)
        {
            return isFirstCall ? _sortedSet.Take(1000).ToList() : _sortedSet.Where(log => log.Time > requestedTime).ToList();
        }
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