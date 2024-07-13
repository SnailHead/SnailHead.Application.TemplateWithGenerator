#nullable disable
using Service.TemplateController.DAL.Application;
using Service.TemplateController.DAL.Application.Filters;

namespace Service.TemplateController.DAL.Entities;

public class Restaurant : IEntity
{
    public Restaurant()
    {
    }

    public Guid Id { get; set; }

    public int SellerId { get; set; }

    public string Name { get; set; }    

    public string ImageUrl { get; set; }

    public string Address { get; set; }

    public string Description { get; set; }


    public string SortKey { get; set; }
    
    [IncludeInFilterModel(ConditionsEnum.Equals)]
    public int? HotelId { get; set; }

    public bool HasDelivery { get; set; }

    public bool HasTableReservation { get; set; }

    public string ApproximateDeliveryTime { get; set; }

    public double? Rating { get; set; }

    public int? TimeBeforeDeliveryStop { get; set; }

    public int? TimeBeforeCreateOrderStop { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    public string RedirectLink { get; set; }

    public string TelegramBotToken { get; set; }

    public string Email { get; set; }
    
    public string KeyWords { get; set; }

    public ICollection<RestaurantImage> RestaurantImages { get; set; } = new List<RestaurantImage>();
    
    public ICollection<RestaurantOrder> RestaurantOrders { get; set; }= new List<RestaurantOrder>();

}