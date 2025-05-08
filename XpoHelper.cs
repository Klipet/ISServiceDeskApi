using DevExpress.Xpo.DB;
using DevExpress.Xpo;

namespace ISServiceDeskApi
{
    public class XpoHelper
    {
        public static void InitConnection()
        {
            string connectionString =
                PostgreSqlConnectionProvider.GetConnectionString(
                    server: "localhost",
                    userId: "postgres",
                    password: "Admin@123",
                    database: "xpo_test_db"
                );

            var dataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            XpoDefault.DataLayer = dataLayer;
            XpoDefault.Session = null;
            
        }
    }
}
