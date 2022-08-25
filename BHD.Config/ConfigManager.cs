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

        private static readonly Lazy<ConfigManager> config = new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance
        {
            get
            {
                return config.Value;
            }
        }

        private ConfigManager()
        {
            configService = new ConfigService(new ConfigFile());
        }

        //public methods

        /// <summary>
        /// Loads config file of json format from app folder
        /// </summary>
        /// <param name="configFileName">Config file name</param>
        /// <returns></returns>
        public bool LoadConfiguration(string configFileName)
        {
            return configService.LoadConfiguration(configFileName);
        }

        /// <summary>
        /// Returns integer from config
        /// </summary>
        /// <param name="jsonPath">Internal json path</param>
        /// <returns></returns>
        public int GetInt(string jsonPath)
        {
            return configService.GetInt(jsonPath);
        }

        /// <summary>
        /// Returns string from config
        /// </summary>
        /// <param name="jsonPath">Internal json path</param>
        /// <returns></returns>
        public string GetString(string jsonPath)
        {
            return configService.GetString(jsonPath);
        }

        /// <summary>
        /// Returns bool from config
        /// </summary>
        /// <param name="jsonPath">Internal json path</param>
        /// <returns></returns>
        public bool GetBool(string jsonPath)
        {
            return configService.GetBool(jsonPath);
        }
    }
}
