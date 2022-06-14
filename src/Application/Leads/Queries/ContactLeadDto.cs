using fw.Application.Common.Mappings;
using fw.Domain.Leads;

namespace fw.Application.Leads.Queries;

public class ContactLeadDto : IMapFrom<Contact>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}
