using DevExpress.Xpo;

namespace ISServiceDeskApi.Entities;

[Persistent("Companies")]
public class CompanyEntity(Session session) : XPLiteObject(session)
{
    [Key(true)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Logo { get; set; }
    public string IDNO { get; set; }
    public bool Status { get; set; }

    [Association("Company-Users")]
    public XPCollection<UserEntity> Users => GetCollection<UserEntity>(nameof(Users));
}