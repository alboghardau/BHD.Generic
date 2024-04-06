using BHD.Logger.Library.Models;

namespace BHD.Logger.Library.Interfaces
{
    public interface IConsoleWriter
    {
        public void WriteLog(Log log);
    }
}

