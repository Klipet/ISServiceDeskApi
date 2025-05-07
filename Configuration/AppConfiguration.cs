namespace ISServiceDeskApi.Configuration
{
    public static class AppConfiguration
    {
        public static void AddAppConfiguration(this IHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
            });
        }
    }
}
