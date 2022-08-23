﻿using System;
using Newtonsoft.Json.Linq;

namespace BHD.Config.Models
{
    public class ConfigFile
    {
        private JObject _configuration;
        private string _path;

        #region Properties

        public JObject Configuration { get; set; }
        public string Path { get; set; }

        #endregion
    }
}

