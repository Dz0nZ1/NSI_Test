using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Test.Infrastructure.Configuration;
using Test.Infrastructure.Contexts;

namespace Test.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,  IConfiguration configuration)
    {
        var dbConfiguration = new PostgresDbConfiguration();
        configuration.GetSection("PostgresDbConfiguration").Bind(dbConfiguration);


        services.AddDbContext<TestDbContext>(

            options => options.UseNpgsql(dbConfiguration.ConnectionString,
                x => x.MigrationsAssembly(typeof(TestDbContext).Assembly.FullName))

        );


       return services;
    }
    
    
}