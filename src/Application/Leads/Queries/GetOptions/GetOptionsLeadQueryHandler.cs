using fw.Domain.Enums;
using MediatR;

namespace fw.Application.Leads.Queries.GetOptions;

public class GetOptionsLeadQueryHandler : IRequestHandler<GetOptionsLeadQuery, IEnumerable<LeadStatusDto>>
{
    public Task<IEnumerable<LeadStatusDto>> Handle(GetOptionsLeadQuery request, CancellationToken cancellationToken)
    {
        return Task.Run(() => new LeadStatus[] { LeadStatus.Invited, LeadStatus.Accepted }
                .Select(p => new LeadStatusDto { Value = (int)p, Name = p.ToString() }));
    }
}