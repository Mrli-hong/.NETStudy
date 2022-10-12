using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIYConfiguration.Model
{
    //按照扁平结构所创建的类
    class WebConfig
    {
        public ConnecStr Conn1 { get; set; }
        public ConnecStr Conn2 { get; set; }
        public Config Config { get; set; }
    }
    class ConnecStr
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
    class Config
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Proxy Proxy { get; set; }
    }
    class Proxy
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public int[] Ids { get; set; }
    }
}
