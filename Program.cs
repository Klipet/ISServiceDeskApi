using ISServiceDeskApi.Configuration;


namespace ISServiceDeskApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args)
                .UseWindowsService(); // Работает как Windows-сервис
            builder.AddLogging();
            builder.AddAppConfiguration();
            builder.AddWebHostConfiguration();

            builder.Build().Run();
        }
       
    }
}
