using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Database;

namespace Service.TemplateController.PL.Definitions.DatabaseSeeding
{
    public class DatabaseSeedingDefinition : ApplicationDefinition
    {
        public override Task ConfigureServicesAsync(IDefinitionServiceContext context)
        {
            context.ServiceCollection.AddSingleton<DatabaseInitializer>();

            return base.ConfigureServicesAsync(context);
        }

        public override Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
        {
            try
            {
                var initializer = context.ServiceProvider.GetRequiredService<DatabaseInitializer>();
                //Without await because mass transit cannot get response
                initializer.Seed();
            }
            catch (Exception ex)
            {
                var logger = context.ServiceProvider.GetRequiredService<ILogger<DatabaseSeedingDefinition>>();
                logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }
    }
}
