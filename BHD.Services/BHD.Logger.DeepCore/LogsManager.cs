using BHD.Logger.DeepCore.Storage;
using BHD.Logger.Library.Enums;
using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore;

public class LogsManager
{
    private readonly DeepStorage _storage;
    private readonly FilterEngine _filterEngine;

    public LogsManager(DeepStorage storage, FilterEngine filterEngine)
    {
        _storage = storage;
        _filterEngine = filterEngine;
    }

    /// <summary>
    /// Returns the last logs after a specified DateTime
    /// </summary>
    public List<Log> GetLogsAfterDateTime(DateTime requestedTime, bool isFirstCall = false)
    {
        lock (_storage.Logs)
        {
            return isFirstCall ? _storage.Logs.Take(1000).ToList() : _storage.Logs.Where(log => log.Time > requestedTime).ToList();
        }
    }

    public List<Log> GetLastCriticalLogs()
    {
        lock (_storage.Logs)
        {
            return _storage.Logs
                .Where(x => x.LogLevel == LogLevel.Error || x.LogLevel == LogLevel.Fatal)
                .Take(10)
                .ToList();
        }
    }
}
