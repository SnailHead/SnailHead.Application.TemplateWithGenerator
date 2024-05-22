using Microsoft.Extensions.DependencyInjection;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.BL.Services;

namespace Service.TemplateController.Test.Definitions.Services;

public class ServiceDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.Scan(scan =>
        {
            scan.FromAssemblyOf<RestaurantService>()
                .AddClasses(classes => classes.Where(c => !c.IsAbstract && c.GetInterfaces().Any()))
                .AsImplementedInterfaces()
                .WithScopedLifetime();
        });
    }
}