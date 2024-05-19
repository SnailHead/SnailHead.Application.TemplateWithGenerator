﻿using Pepegov.MicroserviceFramework.AspNetCore.WebApplicationDefinition;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.BL.Services;

namespace Service.TemplateController.PL.Definitions.Base;

/// <summary>
/// AspNetCore common configuration
/// </summary>
public class CommonDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.AddHttpContextAccessor();
        context.ServiceCollection.AddMemoryCache();
        context.ServiceCollection.AddResponseCaching();
        context.ServiceCollection.AddControllers();
        context.ServiceCollection.Scan(scan =>
        {
            scan.FromAssemblyOf<RestaurantService>()
                .AddClasses(classes => classes.Where(c => !c.IsAbstract && c.GetInterfaces().Any()))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
    }

    public override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
    {
        var app = context.Parse<WebDefinitionApplicationContext>().WebApplication;
    }
}