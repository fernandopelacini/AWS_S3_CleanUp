using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace AWS.S3.CleanUp
{
    public static class Constants
    {
        private static IConfiguration _config;
        public static IConfiguration config
        {
            set
            {
                _config = value;
            }
        }

        public static string AWSConfigFilePath
        {
            get
            {
                return _config.GetSection("Paths:EnvironmentConfigFile").Value.ToString();
            }
        }



    }
}
