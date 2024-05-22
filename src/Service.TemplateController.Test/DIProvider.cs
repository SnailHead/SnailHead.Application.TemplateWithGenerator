using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pepegov.MicroserviceFramework.Definition;
using Pepegov.MicroserviceFramework.Definition.Context;
using Serilog;
using Serilog.Events;

namespace Service.TemplateController.Test;

public class DIProvider
{
    public static IServiceCollection Services { get; set; }
    public static IServiceProvider ServiceProvider { get; set; }

    static DIProvider()
    {
        //Create configuration
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Test.json")
            .Build();

        //Configure logging
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();
        //Create collection
        Services = new ServiceCollection();

        Services.AddSingleton<IConfiguration>(configuration);

        //Add definitions
        Services.AddApplicationDefinitions(new DefinitionServiceContext(Services, configuration), typeof(DIProvider).Assembly).Wait();

        //Add logging
        Services.AddLogging(builder => builder.AddSerilog(dispose: true));

        //Build
        ServiceProvider = Services.BuildServiceProvider();

        //Use definitions
        ServiceProvider.UseApplicationDefinitions(new DefinitionApplicationContext(ServiceProvider)).Wait();
    }

}