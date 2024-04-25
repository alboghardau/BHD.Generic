using BHD.LogsSimulator.Mock;
using ILogger = BHD.Logger.Library.Interfaces.ILogger;

namespace BHD.LogsSimulator.Services
{
    public class MockService : IMockService
    {
        private readonly ILogGenerator _logGenerator;
        private readonly ILogger _logger;
        private Thread? mockThread;
        private bool stopRequested = false;

        public MockService(ILogGenerator logGenerator, ILogger logger)
        {
            _logGenerator = logGenerator;
            _logger = logger;
        }

        public void Start()
        {
            stopRequested = false;
            mockThread = new Thread(GenerateLog);
            mockThread.Start();
        }

        public void Stop()
        {
            if (mockThread != null)
            {
                stopRequested = true;
                mockThread.Join();
            }
        }

        private void GenerateLog()
        {
            while (!stopRequested)
            {
                var log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                log = _logGenerator.GetRandomLog();
                _logger.Add(log);
                //TO DO configurable
                Thread.Sleep(1);
            }
        }
    }
}

