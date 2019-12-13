using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HazırlaWebArkaUç.Yardımcılar;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HazırlaWebArkaUç
{
    public class Program
    {
        private static string depPort, secDepPort, serverAddr;

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            depPort = config.GetValue<string>("DeploymentPort"); secDepPort = config.GetValue<string>("SecureDeploymentPort");

            GüvenlikYardımcı.GüvenlikHizmetUrl = config.GetValue<string>("GüvenlikHizmetUrl") + "/api";
            HazırlaWebYardımcı.ArkaUçHizmetUrl = config.GetValue<string>("ArkaUçİşlemlerHizmetUrl") + "/api";
            HazırlaWebYardımcı.MaliHizmetUrl = config.GetValue<string>("MaliHizmet") + "/api";
            HazırlaWebYardımcı.GünlükHizmetUrl = config.GetValue<string>("OlayGünlüğüHizmet") + "/api";

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseEnvironment("Development");
                    webBuilder.UseIIS();
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://*:{depPort}", $"https://*:{secDepPort}");
                });
    }
}
