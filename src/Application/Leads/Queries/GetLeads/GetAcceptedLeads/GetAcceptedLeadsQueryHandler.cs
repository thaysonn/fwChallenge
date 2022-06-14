using AutoMapper;
using AutoMapper.QueryableExtensions;
using fw.Application.Common.Interfaces;
using fw.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace fw.Application.Leads.Queries.GetLeads.GetAcceptedLeads;

public class GetAcceptedLeadsQueryHandler : IRequestHandler<GetAcceptedLeadsQuery, IEnumerable<LeadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAcceptedLeadsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<LeadDto>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Leads.Where(el => el.Status == LeadStatus.Accepted)
                .Include(a => a.Category)
                .Include(a => a.Contact)
                .AsNoTracking()
                .ProjectTo<LeadDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(t => t.Created)
                .ToListAsync(cancellationToken);
    }
}