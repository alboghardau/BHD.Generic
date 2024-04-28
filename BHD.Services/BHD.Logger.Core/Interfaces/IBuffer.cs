using BHD.Logger.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Logger.Library.Interfaces
{
    public interface IBuffer
    {
        public void Add(Log log);
        public void AddMany(List<Log> logs);
    }
}
