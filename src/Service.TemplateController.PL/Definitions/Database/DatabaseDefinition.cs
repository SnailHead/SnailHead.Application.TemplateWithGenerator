using Microsoft.EntityFrameworkCore;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Service.TemplateController.DAL.Database;

namespace Service.TemplateController.PL.Definitions.Database;

public class DatabaseDefinition : ApplicationDefinition
{
    public override Task ConfigureServicesAsync(IDefinitionServiceContext context)
    {
        string connectionString = context.Configuration.GetConnectionString("DefaultConnection");

        context.ServiceCollection.AddDbContext<DefaultDbContext>(options =>
        {
            options.UseNpgsql(connectionString, b =>
            {
                b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                b.MigrationsAssembly( typeof(DefaultDbContext).Assembly.ToString());
            });
        });
        return base.ConfigureServicesAsync(context);
    }
}