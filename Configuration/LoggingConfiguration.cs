namespace ISServiceDeskApi.Configuration;

public static class LoggingConfiguration
{
    public static void AddLogging(this IHostBuilder builder)
    {
        builder.ConfigureLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddConsole();
            logging.AddEventLog(settings =>
            {
                settings.LogName = "IS";
                settings.SourceName = "ISServiceDesk";
            });
        });
    }
}
