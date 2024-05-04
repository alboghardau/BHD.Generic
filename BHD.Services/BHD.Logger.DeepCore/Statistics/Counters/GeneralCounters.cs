using BHD.Logger.Library.Enums;
using BHD.Logger.Library.Models;

namespace BHD.Logger.DeepCore;

public class GeneralCounters
{
    public long TotalLogsCount { get { return _totalLogsCount; } }
    public long TotalFatalCount { get { return _totalFatalCount; } }
    public long TotalErrorCount { get { return _totalErrorCount; } }

    private long _totalLogsCount = 0;
    private long _totalFatalCount = 0;
    private long _totalErrorCount = 0;

    public GeneralCounters()
    {

    }

    public void CalculateStatistics(List<Log> logs)
    {
        _totalLogsCount += logs.Count;

        _totalFatalCount += logs.Where(log => log.LogLevel == LogLevel.Fatal).Count();

        _totalErrorCount += logs.Where(log => log.LogLevel == LogLevel.Error).Count();
    }
}
