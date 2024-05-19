using Microsoft.IdentityModel.Logging;
using Pepegov.MicroserviceFramework.AspNetCore.WebApplicationDefinition;
using Serilog;
using Serilog.Events;

try
{

    //Create builder
    var builder = WebApplication.CreateBuilder(args);
    
    //Configure logging
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();


    //Host logging  
    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));

    var assembly = typeof(Program).Assembly;
    
    //Add definitions
    await builder.AddApplicationDefinitions(assembly);

    //Create web application
    var app = builder.Build();

    //Use definitions
    await app.UseApplicationDefinitions();
    
    
    //Use logging
    if (app.Environment.IsDevelopment())
    {
        IdentityModelEventSource.ShowPII = true;
    }

    app.UseSerilogRequestLogging();

    //Run app
    await app.RunAsync();

    return 0;
}
catch (Exception ex)
{
    var type = ex.GetType().Name;
    if (type.Equals("HostAbortedException", StringComparison.Ordinal))
    {
        throw;
    }

    Log.Fatal(ex, "Unhandled exception");
    return 1;
}
finally
{
    await Log.CloseAndFlushAsync();
}