using FluentValidation;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.BL.Services.Base;

namespace Service.TemplateController.PL.Definitions.Validators;

public class ValidatorsDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        context.ServiceCollection.AddValidatorsFromAssembly(typeof(Program).Assembly);
        context.ServiceCollection.AddValidatorsFromAssembly(typeof(IBaseService<>).Assembly);
    }
}