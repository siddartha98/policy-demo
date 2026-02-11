
using Microsoft.EntityFrameworkCore;
using PolicyDemo.Domain;

namespace PolicyDemo.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Policy> Policies => Set<Policy>();

    public void Seed()
    {
        if (Policies.Any()) return;

        Policies.AddRange(
            new Policy { PolicyNumber = 1001, CustomerName = "Alice", StartDate = DateTime.UtcNow.AddMonths(-2), EndDate = DateTime.UtcNow.AddMonths(10) },
            new Policy { PolicyNumber = 1002, CustomerName = "Bob", StartDate = DateTime.UtcNow.AddMonths(-1), EndDate = DateTime.UtcNow.AddMonths(5) },
            new Policy { PolicyNumber = 1003, CustomerName = "Charlie", StartDate = DateTime.UtcNow.AddMonths(-6), EndDate = DateTime.UtcNow.AddMonths(-1) }
        );

        SaveChanges();
    }
}
