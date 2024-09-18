namespace DineinEasy.Service.Models;

public partial class AreaModel
{
    public int Id { get; set; }

    public string Ward { get; set; }

    public string District { get; set; }

    public string City { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<RestaurantModel> Restaurants { get; set; } = new List<RestaurantModel>();
}