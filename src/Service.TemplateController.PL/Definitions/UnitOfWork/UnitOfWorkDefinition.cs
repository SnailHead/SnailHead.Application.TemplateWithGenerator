using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Pepegov.UnitOfWork;
using Pepegov.UnitOfWork.EntityFramework.Configuration;
using Service.TemplateController.DAL.Database;

namespace Service.TemplateController.PL.Definitions.UnitOfWork
{
    public class UnitOfWorkDefinition : ApplicationDefinition
    {
        public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
        {
            context.ServiceCollection.AddUnitOfWork(x =>
            {
                x.UsingEntityFramework((context, configurator) =>
                {
                    configurator.DatabaseContext<DefaultDbContext>();
                });
            });
            await base.ConfigureServicesAsync(context);
        }
    }
}