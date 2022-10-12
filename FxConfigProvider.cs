using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DIYConfiguration
{
    class FxConfigProvider : FileConfigurationProvider
    {
        public FxConfigProvider(FxConfigSource sorce):base(sorce) 
        {
            
        }
        //参数stream为获取到的文件的文件流在FileConfigurationProvider中的FileConfigurationSource对象身上有获取配置的来源文件的Path等信息
        public override void Load(Stream stream)
        {
            //创建一个忽略大小写的Dictionary类型的对象
            var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            XmlDocument xmlDoc = new XmlDocument();
            //将获取的文件流加载到xml对象中
            xmlDoc.Load(stream);
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes($"configuration/connectionStrings/add");
            foreach (XmlNode xmlNode in xmlNodeList.Cast<XmlNode>())
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;
                XmlAttribute provider = xmlNode.Attributes["providerName"];
                if (provider is not null)
                {
                    string providerName = provider.Value;
                    data[$"{name}:ProviderName"] = providerName;
                }
                //将读取到的数据进行处理
                data[$"{name}:ConnectionString"] = connectionString;
            }
            XmlNodeList xmlNodeList2 = xmlDoc.SelectNodes($"configuration/appSettings/add");
            foreach (XmlNode item in xmlNodeList2.Cast<XmlNode>())
            {
                string key = item.Attributes["key"].Value.Replace('.', ':');
                string value = item.Attributes["value"].Value;
                data[key] = value;
            }
            this.Data = data;
        }
    }
}
