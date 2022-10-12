using DIYConfiguration.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIYConfiguration
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddScoped<TestFxConfig>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            //自定义的扩展方法
            builder.AddFxConfiguration();
            IConfigurationRoot root = builder.Build();

            services.AddOptions().Configure<WebConfig>(e => root.Bind(e));

            using (var provider = services.BuildServiceProvider())
            {
                TestFxConfig test = provider.GetService<TestFxConfig>();
                test.Test();
            }
        }
    }
}
