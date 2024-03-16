using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Test.Application.Common.Behaviours;

namespace Test.Application;

public static class DependencyInjection
{
    
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        
        return services;
    }
    
}