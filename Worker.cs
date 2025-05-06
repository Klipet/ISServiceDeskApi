using DevExpress.Xpo.DB;
using DevExpress.Xpo;

namespace ISServiceDeskApi
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Сервис запущен в {time}", DateTimeOffset.Now);

            var connectionString =
               PostgreSqlConnectionProvider.GetConnectionString(
                   server: "localhost",
                   userId: "postgres",
                   password: "Admin@123",
                   database: "xpo_test_db"
               );
            var dataStore = XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.SchemaAlreadyExists);
            XpoDefault.DataLayer = new SimpleDataLayer(dataStore);
            XpoDefault.Session = null;

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Работаем в {time}", DateTimeOffset.Now);
              
                await Task.Delay(5000, stoppingToken);
            }
            _logger.LogInformation("Сервис остановлен в {time}", DateTimeOffset.Now);
        }
    }
}
