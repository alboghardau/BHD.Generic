using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MServ.Auth.Config.Interfaces
{
    public interface IConfigManager
    {
        /// <summary>
        /// Loads the configuration from json
        /// </summary>
        /// <param name="configFileName">Name of json file</param>
        public void LoadConfiguration(string configFileName);
    }
}
