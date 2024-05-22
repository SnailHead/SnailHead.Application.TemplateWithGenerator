using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Database;

namespace Service.TemplateController.Test.Definitions.Database;
public class DatabaseDefinition : ApplicationDefinition
{
    public override async Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        string connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        context.ServiceCollection.AddDbContext<DefaultDbContext>(options =>
            options.UseNpgsql(connectionString));
    }
}

