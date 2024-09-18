namespace DineinEasy.Service.Models;

public partial class PackageModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public int ValueDays { get; set; }

    public double Price { get; set; }

    public double Discount { get; set; }

    public bool Status { get; set; }

    public DateTime CreateAt { get; set; }

    public virtual ICollection<OrderMembershipModel> OrderMemberships { get; set; } = new List<OrderMembershipModel>();
}