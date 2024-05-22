using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Domain;
using Service.TemplateController.Test.Definitions.Options.Models;

namespace Service.TemplateController.Test.Definitions.Options;

public class OptionsDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        var identityConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppData.IdentitySettingPath)
            .Build();
        
        context.ServiceCollection.Configure<IdentityAddressOption>(context.Configuration.GetSection("IdentityServerUrl"));
        context.ServiceCollection.Configure<Models.IdentityClientOption>(identityConfiguration.GetSection("CurrentIdentityClient"));

    }
}
