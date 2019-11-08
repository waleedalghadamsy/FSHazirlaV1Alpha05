using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OlayGünlüğüHizmet
{
    public class Program
    {
        private static string depPort, serverAddr;

        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

            depPort = config.GetValue<string>("DeploymentPort");

            BisiparişVeriAltYapı.BisiparişVeriYardımcı.BağlantıDizesi = config.GetValue<string>("ConnectionStrings:BisiparişVT");

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls($"http://*:{depPort}", $"http://0.0.0.0:{depPort}");
                    webBuilder.UseIIS();
                });
    }
}
