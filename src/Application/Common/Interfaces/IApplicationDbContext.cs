using fw.Domain.Leads;
using Microsoft.EntityFrameworkCore;

namespace fw.Application.Common.Interfaces;

public interface IApplicationDbContext
{ 
    DbSet<Lead> Leads { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
