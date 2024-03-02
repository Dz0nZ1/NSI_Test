using Microsoft.Extensions.DependencyInjection;

namespace Test.Application;

public static class DependencyInjection
{


    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        return services;
    }
    
}