using Microsoft.EntityFrameworkCore;
using Service.TemplateController.DAL.Entities;

namespace Service.TemplateController.DAL.Database;

public class DefaultDbContext : DbContext
{
    public DefaultDbContext()
    {
    }

    public DefaultDbContext(DbContextOptions<DefaultDbContext> options)
        : base(options)
    {
    }

    
    public DbSet<Restaurant> Restaurants { get; set; }

    public DbSet<RestaurantImage> RestaurantImages { get; set; }

    public DbSet<RestaurantOrder> RestaurantOrders { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}