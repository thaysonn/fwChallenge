using AutoMapper;
using fw.Application.Common.Mappings;
using fw.Domain.Enums;
using fw.Domain.Leads;

namespace fw.Application.Leads.Queries;

public class LeadDto : IMapFrom<Lead>
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public string? Suburb { get; set; }
    public string? Category { get; set; }
    public LeadStatus Status { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public ContactLeadDto? Contact { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Lead, LeadDto>()
            .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Description))
            .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price.Value));
    }
}
