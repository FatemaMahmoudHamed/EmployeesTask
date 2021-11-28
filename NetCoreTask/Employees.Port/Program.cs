using Employees.Infrastructure;
using Employees.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Port
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //CreateHostBuilder(args).Build().Run();
            //var host = CreateHostBuilder(args).Build();
            try
            {

                // Initialize the database.
                var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

                using (var scope = scopeFactory.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<CommandDbContext>();

                    if (db.Database.EnsureCreated())
                    {
                        Log.Information("Initializing Database.");
                        SeedData.Initialize(db, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development);
                        Log.Information("Database initialized successfully.");
                    }
                }

                Log.Information("NetCoreTask Legal Affairs Web API is Starting Up.");


                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "NetCoreTask Legal Affairs Web API failed to start.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}
