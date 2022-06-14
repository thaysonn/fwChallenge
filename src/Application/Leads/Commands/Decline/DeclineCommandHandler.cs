using fw.Application.Common.Exceptions;
using fw.Application.Common.Interfaces;
using fw.Domain.Leads;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace fw.Application.Leads.Commands.Decline;

public class DeclineCommandHandler : IRequestHandler<DeclineCommand>
{
    private readonly IApplicationDbContext _context;

    public DeclineCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(DeclineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Leads
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Lead), request.Id);

        entity.Decline(); 
        _context.Leads.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}