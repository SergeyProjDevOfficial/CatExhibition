using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseWorkingLib.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CatExhibition
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateDbIfNotExists(CreateHostBuilder(args).Build()).Run();
        }

        private static IHost CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var context = services.GetRequiredService<ContentTableContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
            return host;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    #if Release
                    webBuilder.UseKestrel();
                    #endif
                });
    }
}
