

#nullable disable
using Service.TemplateController.DAL.Application;

namespace Service.TemplateController.DAL.Entities;

public class RestaurantImage : IEntity
{
  public Guid Id { get; set; }

  public int RestaurantId { get; set; }

  public string ImageUrl { get; set; }

  public string SortKey { get; set; }

  public Restaurant Restaurant { get; set; }
}