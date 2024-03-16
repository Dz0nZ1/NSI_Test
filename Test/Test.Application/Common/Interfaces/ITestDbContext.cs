using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;

namespace Test.Application.Common.Interfaces;

public interface ITestDbContext
{
    public DbSet<Domain.Entities.Product> Products { get; }
    
    public DbSet<Company> Companies { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}