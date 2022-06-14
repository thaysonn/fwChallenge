using fw.Domain.Leads;
using fw.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace fw.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Seed
        if (!_context.Leads.Any())
        {
            _context.Leads.Add(new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(62),
                new Contact() { FirstName = "Bill" },
                new Category("Interior Painters")));

            _context.Leads.Add(new Lead("Woolooware 2230", "Internal walls 3 colours", Price.Of(49),
                new Contact() { FirstName = "Craig" },
                new Category("Painters")));

            _context.Leads.Add(new Lead("Carramar 6031", "Plaster exposed brick walls (see photos), square off 2 archways (see photos), and expand pantry (see photos).", Price.Of(26),
                new Contact()
                {
                    FirstName = "Pete",
                    LastName = "Sanderson",
                    PhoneNumber = "0412345678",
                    Email = "fake@maillinator.com"
                },
                new Category("General Building Work")));


            _context.Leads.Add(new Lead("YanDerra 2574", "Need to paint 3 aluminum windows and a sliding glass door", Price.Of(62),
                new Contact()
                {
                    FirstName = "Chris",
                    LastName = "Sanderson",
                    PhoneNumber = "04987654321",
                    Email = "another.fake@hipmail.com"
                },
                new Category("Home Renovations")));

            await _context.SaveChangesAsync();
        }
    }
}
