namespace ISServiceDeskApi.Configuration;

public static class HostConfiguration
{
    public static void AddWebHostConfiguration(this IHostBuilder builder)
    {
        builder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder
                .UseKestrel()
                .UseUrls("http://localhost:5000") // Слушаем порт
                .UseStartup<Startup>();
        });
    }
}
