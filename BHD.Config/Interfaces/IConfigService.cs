using System;
namespace BHD.Config.Interfaces
{
    public interface IConfigService
    {
        public bool LoadConfiguration(string configFileName);
        public int GetInt(string jsonPath);
        public string GetString(string jsonPath);
        public bool GetBool(string jsonPath);
    }
}

