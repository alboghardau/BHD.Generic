using BHD.Config.Interfaces;
using BHD.Config.Models;
using BHD.Config.Services;
using BHD.Config.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHD.Config
{
    public class ConfigManager  
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

        #region Public

        /// <summary>
        /// Loads config file of json format from app folder
        /// </summary>
        /// <param name="configFileName">Config file name</param>
        /// <returns></returns>
        public bool LoadConfigurationByFileName(string configFileName)
        {
            return configService.LoadConfigurationByFileName(configFileName);
        }

        /// <summary>
        /// Loads config file by path to json file given
        /// </summary>
        /// <param name="fullPath">Full path to json file</param>
        /// <returns></returns>
        public bool LoadConfigurationByPath(string fullPath)
        {
            return configService.LoadConfigurationByPath(fullPath);
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

        #endregion
    }
}
