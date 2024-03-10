using BHD.Logger.Library.Models;

namespace BHD.Logger.Library.Interfaces
{
    public interface ILogWriter
    {
        public void WriteLog(Log log);
    }
}

