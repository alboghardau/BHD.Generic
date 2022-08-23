using System;
using BHD.Config.Interfaces;
using BHD.Config.Models;
using Newtonsoft.Json.Linq;

namespace BHD.Config.Services
{
    public class ConfigService : IConfigService
    {
        private ConfigFile _configFile;

        public ConfigService(ConfigFile configFile)
        {
            _configFile = configFile;
        }

        public bool LoadConfiguration(string configFileName)
        {
            try
            {
                string path = Path.Combine(AppContext.BaseDirectory, "Config.json");
                var file = File.ReadAllText(path);
                _configFile.Configuration = JObject.Parse(file);
                return true;
            }
            catch(Exception ex)
            {
                //TODO -add ex
            }
            return false;
        }

        public bool GetBool(string jsonPath)
        {
            var value = ReadValue(jsonPath);
            if (value == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetInt(string jsonPath)
        {
            int num = 0;
            int.TryParse(jsonPath, out num);
            return num;
        }

        public string GetString(string jsonPath)
        {
            return ReadValue(jsonPath);
        }

        #region Privates

        private string ReadValue(string jsonPath)
        {
            var value = _configFile.Configuration.SelectToken(jsonPath);
            if (value != null)
            {
                return value.ToString();
            }
            return String.Empty;
        }

        #endregion
    }
}

