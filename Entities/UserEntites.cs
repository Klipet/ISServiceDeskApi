using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Users")]
    public class UserEntites : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public bool IsSupport { get; set; }
        public String Phone { get; set; }
        public string Login { get; set; }
        public string PasswordHesh { get; set; }
        public string Token { get; set; }

        [Association("Company-Users")]
        public Company Company { get; set; }
        [Association("User-Tickets")]
        public XPCollection<TicketEntites> Tickets => GetCollection<TicketEntites>(nameof(Tickets));
        public UserEntites(Session session) : base(session) { }
    }
}
