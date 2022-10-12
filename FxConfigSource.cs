using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIYConfiguration
{
    class FxConfigSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            //处理对默认值的处理,不加报错
            EnsureDefaults(builder);
            return new FxConfigProvider(this);
        }
    }
}
