using Microsoft.AspNetCore.Diagnostics;
using Pepegov.MicroserviceFramework.AspNetCore.Infrastructure.Filter;
using Pepegov.MicroserviceFramework.AspNetCore.WebApplicationDefinition;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;

namespace Service.TemplateController.PL.Definitions.ExceptionHandler;

public class ExceptionHandlerDefinition : ApplicationDefinition
{
    public override bool Enabled => false;

    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.AddMvc(options => options.Filters.Add<GlobalExceptionFilter>());
    }

    public override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
    {
        var app = context.Parse<WebDefinitionApplicationContext>().WebApplication;
        app.UseMiddleware<ExceptionHandlerMiddleware>();
    }
}