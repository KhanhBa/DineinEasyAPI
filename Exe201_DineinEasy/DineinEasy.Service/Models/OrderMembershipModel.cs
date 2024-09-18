namespace DineinEasy.Service.Models;

public partial class OrderMembershipModel
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int PackageId { get; set; }

    public DateTime ExpiredDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ValueDays { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public double Price { get; set; }

    public double Discount { get; set; }

    public bool Status { get; set; }

    public virtual PackageModel Package { get; set; }

    public virtual RestaurantModel Restaurant { get; set; }
}