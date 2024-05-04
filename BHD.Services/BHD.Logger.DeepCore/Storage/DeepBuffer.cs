using BHD.Logger.Library.Core;
using BHD.Logger.Library.Interfaces;
using BHD.Logger.Library.Models;
using BHD.Logger.Library.Writers;
using System.Collections.Concurrent;
namespace BHD.Logger.DeepCore.Storage
{
    public class DeepBuffer : IBuffer
    {
        private readonly ConcurrentQueue<Log> _logs = new();
        private readonly Timer? _timer;

        private readonly LoggerConfig _config;
        private readonly DeepStorage _storage;
        private readonly ConsoleWriter _consoleWriter;

        public DeepBuffer(LoggerConfig config, DeepStorage storage, ConsoleWriter consoleWriter)
        {
            _config = config;
            _storage = storage;
            _consoleWriter = consoleWriter;

            if (_config.EnableDeepStorage)
            {
                _timer = new Timer(StoreDeep, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(_config.DeepStorageInterval));
            }
        }

        public void Add(Log log)
        {
            if (_config.EnableConsoleWriting)
                _consoleWriter.WriteLog(log);

            _logs.Enqueue(log);
        }

        public void AddMany(List<Log> logs)
        {
            foreach (var log in logs)
            {
                _logs.Enqueue(log);
            }
        }

        private void StoreDeep(object? state)
        {
            Task.Run(() =>
            {
                var logsToSend = _logs.Take(5000).ToList();

                _storage.AddLogs(logsToSend);

                for (var i = 0; i < logsToSend.Count; i++)
                {
                    _logs.TryDequeue(out _);
                }
            });
        }
    }
}
