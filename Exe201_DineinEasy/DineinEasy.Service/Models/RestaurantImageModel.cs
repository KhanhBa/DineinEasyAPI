namespace DineinEasy.Service.Models;

public partial class RestaurantImageModel
{
    public int Id { get; set; }

    public string ImageUrl { get; set; }

    public int? RestaurantId { get; set; }

}