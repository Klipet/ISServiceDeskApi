namespace ISServiceDeskApi.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            XpoHelper.InitConnection();
        }
    }
}
