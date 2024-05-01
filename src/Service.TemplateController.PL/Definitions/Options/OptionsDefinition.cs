using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Domain;
using Service.TemplateController.PL.Definitions.Options.Models;

namespace Service.TemplateController.PL.Definitions.Options;

public class OptionsDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        var identityConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppData.IdentitySettingPath)
            .Build();

        context.ServiceCollection.Configure<IdentityClientOption>(identityConfiguration.GetSection("CurrentIdentityClient"));
    }
}