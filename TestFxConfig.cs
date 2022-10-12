using DIYConfiguration.Model;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIYConfiguration
{
    class TestFxConfig
    {
        private IOptionsSnapshot<WebConfig> options;
        public TestFxConfig(IOptionsSnapshot<WebConfig> options)
        {
            this.options = options;
        }
        public void Test()
        {
            var result = options.Value;
            Console.WriteLine(result.Config.Age);
            Console.WriteLine(result.Config.Proxy.Address);
            Console.WriteLine(result.Config.Proxy.Ids[1]);
            Console.WriteLine(result.Conn1.ConnectionString);
            Console.WriteLine(result.Conn1.ProviderName);
        }
    }
}
