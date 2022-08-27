using System;
namespace BHD.Config.Interfaces
{
    public interface IConfigService
    {
        public bool LoadConfigurationByFileName(string configFileName);
        public bool LoadConfigurationByPath(string fullPath);
        public int GetInt(string jsonPath);
        public string GetString(string jsonPath);
        public bool GetBool(string jsonPath);
    }
}

