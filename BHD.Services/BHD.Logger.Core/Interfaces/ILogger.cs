using BHD.Logger.Library.Models;

namespace BHD.Logger.Library.Interfaces
{
    public interface ILogger
    {
        public void Add(Log log);
        public void Verbose(string message);
        public void Trace(string message);
        public void Information(string message);
        public void Warning(string message);
        public void Error(string message);
        public void Fatal(string message);
    }
}