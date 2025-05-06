using DevExpress.Xpo;

namespace ISServiceDeskApi.ModelDB
{
    [Persistent("Users")]
    public class User : XPLiteObject
    {
        [Key(true)]
        public int ID { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
        public String Phone { get; set; }
        public string Login { get; set; }
        public string PasswordHesh { get; set; }

        [Association("Company-Users")]
        public Company Company { get; set; }
        [Association("User-Tickets")]
        public XPCollection<Ticket> Tickets => GetCollection<Ticket>(nameof(Tickets));
        public User(Session session) : base(session) { }
    }
}
