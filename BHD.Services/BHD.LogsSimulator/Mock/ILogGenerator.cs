using BHD.Logger.Library.Models;

namespace BHD.LogsSimulator.Mock
{
    public interface ILogGenerator
    {
        public Log GetRandomLog();
    }
}

