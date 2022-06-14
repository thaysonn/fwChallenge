using MediatR;

namespace fw.Application.Leads.Queries.GetOptions;
public record GetOptionsLeadQuery : IRequest<IEnumerable<LeadStatusDto>>;
