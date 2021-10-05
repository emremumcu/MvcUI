namespace MvcUI
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    public class Program
    {
        public static void Main(string[] args)
        {
            //var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            //var logger = loggerFactory.CreateLogger(nameof(Program));
            //logger.LogInformation("Application Started");

            IHost host = CreateHostBuilder(args).Build();

            ILogger logger = host.Services.GetRequiredService<ILogger<Program>>();
            logger.LogInformation("Application Started");

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            // Host.CreateDefaultBuilder method registers hte following logging providers:
            // logging.AddConsole(), logging.AddDebug(), logging.AddEventSourceLogger()
            Host.CreateDefaultBuilder(args)
                // .ConfigureLogging(logging => { logging.ClearProviders(); logging.AddConsole(); }) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
