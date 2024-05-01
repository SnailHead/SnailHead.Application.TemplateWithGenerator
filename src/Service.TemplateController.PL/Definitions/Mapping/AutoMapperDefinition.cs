using Pepegov.MicroserviceFramework.AspNetCore.WebApplicationDefinition;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;

namespace Service.TemplateController.PL.Definitions.Mapping;

public class AutoMapperDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
        => context.ServiceCollection.AddAutoMapper(typeof(Program));

    public override async Task ConfigureApplicationAsync(IDefinitionApplicationContext context)
    {
        var app = context.Parse<WebDefinitionApplicationContext>().WebApplication;
        var mapper = context.ServiceProvider.GetRequiredService<AutoMapper.IConfigurationProvider>();
        if (app.Environment.IsDevelopment())
        {
            mapper.AssertConfigurationIsValid();
        }
        else
        {
            mapper.CompileMappings();
        }
    }
}