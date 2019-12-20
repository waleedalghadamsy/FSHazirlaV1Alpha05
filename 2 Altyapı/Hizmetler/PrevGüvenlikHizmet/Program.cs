using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GüvenlikHizmet
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

            HazırlaVeriAltYapı.HazırlaVeriYardımcı.BağlantıDizesi = config.GetValue<string>("ConnectionStrings:HazırlaVT");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://*:{depPort}", $"https://*:{secDepPort}");
                    //webBuilder.UseIIS();
                });
    }
}
