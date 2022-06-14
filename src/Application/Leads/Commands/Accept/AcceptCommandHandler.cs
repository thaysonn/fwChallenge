using fw.Application.Common.Exceptions;
using fw.Application.Common.Interfaces;
using fw.Domain.Events;
using fw.Domain.Leads;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace fw.Application.Leads.Commands.Accept;

public class AcceptCommandHandler : IRequestHandler<AcceptCommand>
{
    private readonly IApplicationDbContext _context;

    public AcceptCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<Unit> Handle(AcceptCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Leads
            .Include(l => l.Contact)
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        if (entity == null) throw new NotFoundException(nameof(Lead), request.Id);

        entity.Accept();
        _context.Leads.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}