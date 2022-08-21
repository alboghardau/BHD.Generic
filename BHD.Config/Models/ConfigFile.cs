using System;
using Newtonsoft.Json.Linq;

namespace BHD.Config.Models
{
    public class ConfigFile
    {
        private JObject _configuration;

        #region Properties

        public JObject Configuration { get; set; }

        #endregion
    }
}

