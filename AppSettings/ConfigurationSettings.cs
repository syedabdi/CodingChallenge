using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppSettings
{
    public static class ConfigurationSettings
    {
        public static IConfigurationRoot GetConfiguration(string contentRoot)
        {
            return (new ConfigurationBuilder())
                    .SetBasePath(contentRoot)
                    .AddJsonFile(contentRoot + "\\appsettings.json", true, true)
                    .AddEnvironmentVariables()
                    .Build();
        }
        public static string GetDbConnectionString(IConfigurationRoot _config)
        {
            return _config["connectionStrings:EmployeeDBConnectionString"];
        }
    }
}
