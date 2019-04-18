using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace full_featflag_sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) => {
                    if (context.HostingEnvironment.IsProduction()){
                        var builtConfig = config.Build();

                        config.AddAzureKeyVault(
                            $"https://{builtConfig["KeyVault:Name"]}.vault.azure.net/", 
                            builtConfig["KeyVault:AppId"], 
                            builtConfig["KeyVault:AppSecret"]);
                    }
                })
                .UseStartup<Startup>();
    }
}
