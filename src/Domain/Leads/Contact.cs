namespace fw.Domain.Leads;
public class Contact : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName { get { return FirstName + " " + LastName; } }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}
