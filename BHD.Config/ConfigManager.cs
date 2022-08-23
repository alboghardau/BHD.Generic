using BHD.Config.Interfaces;
using BHD.Config.Models;
using BHD.Config.Services;
using MServ.Auth.Config.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MServ.Auth.Config
{
    public class ConfigManager : IConfigManager     
    {
        private IConfigService configService;

        public ConfigManager()
        {
            configService = new ConfigService(new ConfigFile());
        }

        public void LoadConfiguration(string configFileName)
        {
            configService.LoadConfiguration(configFileName);
        }

        public int GetInt(string jsonPath)
        {
            return configService.GetInt(jsonPath);
        }

        public string GetString(string jsonPath)
        {
            return configService.GetString(jsonPath);
        }

        public bool GetBool(string jsonPath)
        {
            return configService.GetBool(jsonPath);
        }
    }
}
