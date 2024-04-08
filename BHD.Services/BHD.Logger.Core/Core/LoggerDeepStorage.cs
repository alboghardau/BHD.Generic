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

    public void AddLogs(List<Log> logs)
    {
        foreach (var log in logs)
        {
            _sortedSet.Add(log);
        }
    }
}