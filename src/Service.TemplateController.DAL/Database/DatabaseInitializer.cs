using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Service.TemplateController.DAL.Entities;

namespace Service.TemplateController.DAL.Database;

public class DatabaseInitializer
{
    private readonly IServiceProvider _serviceProvider;

    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Seed()
    {
        await using var scope = _serviceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<DefaultDbContext>();
        await context!.Database.MigrateAsync();
        var restaurant = new Restaurant()
        {
            Rating = new Random().Next(1, 6),
            Name = "Рестик " + DateTime.UtcNow.Ticks,
            TelegramBotToken = "6992974718:AAGMgdgDmYCRZfpnRs5LWmxtm_10Ao9UjHg",
        };
        await context.Restaurants.AddAsync(restaurant);

        await context.SaveChangesAsync();
    }
}