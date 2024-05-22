﻿using Pepegov.MicroserviceFramework.AspNetCore.WebApplicationDefinition;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;

namespace Service.TemplateController.PL.Definitions.Base;

/// <summary>
/// AspNetCore common configuration
/// </summary>
public class CommonDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.AddHttpContextAccessor();
        context.ServiceCollection.AddResponseCaching();
        context.ServiceCollection.AddControllers();
    }

    public override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
    {
        var app = context.Parse<WebDefinitionApplicationContext>().WebApplication;
    }
}