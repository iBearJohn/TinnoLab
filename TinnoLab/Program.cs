using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TinnoLab.DataContext;

namespace TinnoLab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the Host which will host this application.
            var host = CreateHostBuilder(args).Build();

            // Find the service layer within our scope.
            using (var scope = host.Services.CreateScope())
            {
                // Get the instance of TopicDBContext in our services layer
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<TopicDBContext>();

                // Call the DataGenerator to create sample data
                Models.DataGenerator.Initialize(services);
            }

            // Continue to run the application
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
