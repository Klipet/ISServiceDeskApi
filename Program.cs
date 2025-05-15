using ISServiceDeskApi.Configuration;


namespace ISServiceDeskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args).UseWindowsService();
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
            builder.AddLogging();
         //   builder.AddAppConfiguration();
            builder.AddWebHostConfiguration();

            builder.Build().Run();
        }
       
    }
}
