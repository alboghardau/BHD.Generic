using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MServ.Auth.Config.Interfaces
{
    public interface IConfigManager
    {
        public bool LoadConfiguration(string configFileName);
    }
}
