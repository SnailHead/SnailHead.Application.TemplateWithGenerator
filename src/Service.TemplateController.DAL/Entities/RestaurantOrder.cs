#nullable disable
using Service.TemplateController.DAL.Application;

namespace Service.TemplateController.DAL.Entities;

public class RestaurantOrder : IEntity
{

    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public int RestaurantId { get; set; }

    public int StatusId { get; set; }

    public int? RestaurantTableId { get; set; }

    public DateTime PurchaseDate { get; set; }

    public int PurchaseSum { get; set; }

    public string IpAddress { get; set; }

    public string ExternalPaymentId { get; set; }

    public int PaymentStatusId { get; set; }

    public int PaymentMethodId { get; set; }

    public string ReceiptUrl { get; set; }

    public string AuxiliaryPaymentData { get; set; }

    public int? DeliveryTypeId { get; set; }

    public string Comment { get; set; }

    public string Address { get; set; }

    public string DeliveryTime { get; set; }

    public string Apartment { get; set; }

    public string Intercom { get; set; }

    public string Entrance { get; set; }

    public string HouseFloor { get; set; }

    public int? GuestsCount { get; set; }

    public DateTime? TakeAwayDate { get; set; }

    public TimeSpan? TakeAwayTime { get; set; }

    public int? IikoOrderStatusId { get; set; }

    public string FullOrderData { get; set; }

    public string ExternalId { get; set; }

    public bool? IsNew { get; set; }

    public int? DeliveryPrice { get; set; }
    
    public Restaurant Restaurant { get; set; }
}