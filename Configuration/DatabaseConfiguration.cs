using DevExpress.Xpo;

namespace ISServiceDeskApi.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            XpoHelper.InitConnection();
         //   StatusConfig.CreateStatuses(new UnitOfWork());
            
        }
    }
}
