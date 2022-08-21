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
        JObject config;
        public ConfigManager()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Config.json");
            var file = File.ReadAllText(path);
            config = JObject.Parse(file);
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

        public bool GetBool(string jsonPath)
        {
            var value = ReadValue(jsonPath);
            if(value == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Private

        private string ReadValue(string jsonPath)
        {
            var value = config.SelectToken(jsonPath);
            if(value != null)
            {
                return value.ToString();
            }
            return String.Empty;
        }

        #endregion
    }
}
