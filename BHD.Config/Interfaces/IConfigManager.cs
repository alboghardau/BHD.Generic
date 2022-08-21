using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MServ.Auth.Config.Interfaces
{
    public  interface IConfigManager
    {
        public int GetInt(string jsonPath);
        public string GetString(string jsonPath);
        public bool GetBool(string jsonPath);
    }
}
