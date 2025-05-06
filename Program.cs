
using DevExpress.Xpo;
using ISServiceDeskApi.ModelDB;
using Microsoft.AspNetCore.Hosting;
using Serilog;


namespace ISServiceDeskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .UseWindowsService() // Работает как Windows-сервис
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddEventLog(settings =>
                    {
                        settings.LogName = "IS";
                        settings.SourceName = "ISServiceDesk";
                    });
                })
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                          .AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel()
                        .UseUrls("http://localhost:5000") // Слушаем порт
                        .UseStartup<Startup>();
                });

            builder.Build().Run();
        }
       
    }
}
