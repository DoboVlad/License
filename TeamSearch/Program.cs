using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TeamSearch.Data;
using TeamSearch.Data.Seed;

namespace TeamSearch
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //get the service from container
            using var scope = host.Services.CreateScope();
            var Services = scope.ServiceProvider;
            
            try
            {
                //populate the database
                var context = Services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await Seed.SeedFields(context);
                await SeedLanguages.SeedLang(context);
            }
            catch(Exception e)
            {
                var logger = Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error occured during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
