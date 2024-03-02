using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Interfaces;
using Test.Domain.Entities;

namespace Test.Infrastructure.Contexts;

public class TestDbContext(DbContextOptions<TestDbContext> options) : IdentityDbContext<ApplicationUser,
    ApplicationRole,
    string,
    IdentityUserClaim<string>,
    ApplicationUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>
>(options), ITestDbContext


{

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=root;Database=Test");
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Company> Companies => Set<Company>();


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new ())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result;
    }
    
}