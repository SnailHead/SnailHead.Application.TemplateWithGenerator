using Microsoft.Extensions.DependencyInjection;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Database;

namespace Service.TemplateController.Test.Definitions.DatabaseSeeding;

public class DatabaseSeedingDefinition : ApplicationDefinition
{
    public override bool Enabled => false;

    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.AddSingleton<DatabaseInitializer>();
    }

    public override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
    {
        context.ServiceProvider.GetService<DatabaseInitializer>()!.Seed();
    }
}