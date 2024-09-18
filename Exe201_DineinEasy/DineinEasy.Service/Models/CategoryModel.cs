namespace DineinEasy.Service.Models;

public partial class CategoryModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<RestaurantModel> Restaurants { get; set; } = new List<RestaurantModel>();
}