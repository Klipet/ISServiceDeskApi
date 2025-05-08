using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using ISServiceDeskApi.ModelDB;

namespace ISServiceDeskApi.Configuration
{
    public static class StatusConfig
    {

        public static void CreateStatuses(UnitOfWork uow)
        {
            string[] defaultStatuses = { "Новый", "В работе", "Закрыт" };

            foreach (var name in defaultStatuses)
            {
                var exists = uow.FindObject<StatusEntites>(
                    CriteriaOperator.Parse("Name == ?", name)
                );

                if (exists == null)
                {
                    new StatusEntites(uow)
                    {
                        Name = name
                    };
                }
            }

            uow.CommitChanges();
        }
    }
}
