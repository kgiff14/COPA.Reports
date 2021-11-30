using Conservice.Application;
using Conservice.Logging;
using COPA.Reports.BLL;
using COPA.Reports.BLL.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COPA.Reports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            EnvironmentAccessor environment = new EnvironmentAccessor();
            CreateHostBuilder(args, environment).Build().Run();

            //using IServiceScope serviceScope = host.Services.CreateScope();
            //IServiceProvider provider = serviceScope.ServiceProvider;

            //PaymentBreakdownLogic logic = provider.GetRequiredService<PaymentBreakdownLogic>();

            //logic.GetCOPAPaymentBreakdowns();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, EnvironmentAccessor environment) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    string settingsPrefix = "Default";
                    if (environment.Environment == ApplicationEnvironment.Production)
                    {
                        settingsPrefix = "Production";
                    }

                    config.AddJsonFile($"appsettings.{settingsPrefix}.json", optional: true, reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                     webBuilder.UseStartup<Startup>();
                });
    }
}
