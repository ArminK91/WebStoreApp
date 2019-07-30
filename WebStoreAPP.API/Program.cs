using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Context;
using DomainModels.DbModels.DbInitializer;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebStoreApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = BuildWebHost(args);

            BuildWebHost(args).Run();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<ApplicationDbContext>();
            //        Seed.Seed1(context);//<---Do your seeding here
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //        //var logger = services.GetRequiredService<ILogger<Program>>();
            //        //logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            //host.Run();

        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
