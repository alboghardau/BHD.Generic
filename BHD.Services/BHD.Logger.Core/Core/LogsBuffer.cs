using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using BHD.Logger.Library.Writers;
using System.Collections.Concurrent;

namespace BHD.Logger.Library.Core
{
    public class LogsBuffer : IBuffer
    {
        private readonly ConcurrentQueue<Log> _logs = new ConcurrentQueue<Log>();

        private readonly LoggerConfig _config;
        private readonly ConsoleWriter _consoleWriter;
        private readonly HttpWriter _httpWriter;
        private readonly Timer? _timer;

        public LogsBuffer(LoggerConfig config, 
            ConsoleWriter consoleWriter, 
            HttpWriter httpWriter)
        {
            _consoleWriter = consoleWriter;
            _httpWriter = httpWriter;
            _config = config;

            if (_config.EnableBroadcast)
            {
                _timer = new Timer(BroadcastLogs, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(_config.BroadcastInterval));
            }
        }

        public void Add(Log log)
        {
            if(_config.EnableConsoleWriting)
                _consoleWriter.WriteLog(log);

            _logs.Enqueue(log);
        }

        public void AddMany(List<Log> logs)
        {
            throw new NotImplementedException();
        }

        private async void BroadcastLogs(object? state)
        {
            await Task.Run(async () =>
            {
                if (_logs.IsEmpty) return;

                var logsToSend = _logs.Take(_config.BulkSize).ToList();

                if (await _httpWriter.SendLogsAsync(logsToSend))
                {
                    for (var i = 0; i < logsToSend.Count; i++)
                    {
                        _logs.TryDequeue(out _);
                    }
                }
            });
        }
    }
}
