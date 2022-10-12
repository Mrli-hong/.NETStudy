using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIYConfiguration
{
    public  static class  FxConfigurationExtension
    {
        public static IConfigurationBuilder AddFxConfiguration(this IConfigurationBuilder configuration, string path=null)
        {
            if (path is null)
            {
                path = "web.config";
            }
            return configuration.Add(new FxConfigSource() { Path = path });
        }
    }
}
