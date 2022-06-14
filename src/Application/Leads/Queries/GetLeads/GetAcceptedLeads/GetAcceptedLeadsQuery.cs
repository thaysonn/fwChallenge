using MediatR;

namespace fw.Application.Leads.Queries.GetLeads.GetAcceptedLeads;
public record GetAcceptedLeadsQuery : IRequest<IEnumerable<LeadDto>>;