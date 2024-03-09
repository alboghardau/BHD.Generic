using System;
using BHD.LogsHut.Interfaces;
using BHD.LogsHut.Mock;

namespace BHD.LogsHut.Services
{
	public class MockService : IMockService
	{
		private ILogGenerator logGenerator;
        private LoggerService loggerService;
        private Thread? mockThread;
        private bool stopRequested = false;

		public MockService(ILogGenerator logGenerator, LoggerService loggerService)
		{
			this.logGenerator = logGenerator;
            this.loggerService = loggerService;
		}

        public void Start()
        {
            this.stopRequested = false;
            this.mockThread = new Thread(GenerateLog);
            this.mockThread.Start();
        }

        public void Stop()
        {
            if (this.mockThread != null)
            {
                stopRequested = true;
                this.mockThread.Join();
            }
        }

        private void GenerateLog()
        {
            while (!stopRequested)
            {
                var log = this.logGenerator.GetRandomLog();
                this.loggerService.AddLog(log);

                //TO DO configurable
                Thread.Sleep(1000);
            }
        }
    }
}

