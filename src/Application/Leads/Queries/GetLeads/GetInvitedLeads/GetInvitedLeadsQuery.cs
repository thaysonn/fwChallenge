using MediatR;

namespace fw.Application.Leads.Queries.GetLeads.GetInvitedLeads;
public record GetInvitedLeadsQuery : IRequest<IEnumerable<LeadDto>>;