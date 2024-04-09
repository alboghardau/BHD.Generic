using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using BHD.Logger.Library.Writers;
using System.Collections.Concurrent;

namespace BHD.Logger.Library.Core
{
    public class LoggerStorage
    {
        private readonly LoggerConfig _loggerConfig;
        private readonly ConcurrentQueue<Log> _logsQueue = new ConcurrentQueue<Log>();
        private readonly IConsoleWriter _consoleWriter;
        private readonly HttpWriter _httpWriter;
        private readonly LoggerDeepStorage _deepStorage;
        private readonly Timer? _timer;

        public LoggerStorage(LoggerConfig loggerConfig, 
            IConsoleWriter consoleWriter, 
            HttpWriter httpWriter,
            LoggerDeepStorage deepStorage)
        {
            _consoleWriter = consoleWriter;
            _httpWriter = httpWriter;
            _deepStorage = deepStorage;
            _loggerConfig = loggerConfig;

            if (_loggerConfig.EnableBroadcast)
            {
                _timer = new Timer(BroadcastLogs, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(_loggerConfig.BroadcastInterval));
            }
            else if (_loggerConfig.EnableDeepStorage)
            {
                _timer = new Timer(StoreDeep, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(_loggerConfig.DeepStorageInterval));
            }
        }

        public void Add(Log log)
        {
            if(_loggerConfig.EnableConsoleWriting)
                _consoleWriter.WriteLog(log);
            
            _logsQueue.Enqueue(log);
        }

        public void AddMany(List<Log> logs)
        {
            foreach (var log in logs)
            {
                _logsQueue.Enqueue(log);
            }
        }

        private void StoreDeep(object? state)
        {
            Task.Run(() =>
            {
                var logsToSend = _logsQueue.Take(5000).ToList();
                
                _deepStorage.AddLogs(logsToSend);
                
                for (var i = 0; i < logsToSend.Count; i++)
                {
                    _logsQueue.TryDequeue(out _);
                }
            });
        }

        private async void BroadcastLogs(object? state)
        {
            await Task.Run(async () =>
            {
                if (_logsQueue.IsEmpty) return;

                var logsToSend = _logsQueue.Take(_loggerConfig.BulkSize).ToList();

                if (await _httpWriter.SendLogsAsync(logsToSend))
                {
                    for (var i = 0; i < logsToSend.Count; i++)
                    {
                        _logsQueue.TryDequeue(out _);
                    }
                }
            });
        }
    }
}
