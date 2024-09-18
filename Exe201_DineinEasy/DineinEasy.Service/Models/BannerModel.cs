namespace DineinEasy.Service.Models;

public partial class BannerModel
{
    public int Id { get; set; }

    public DateTime? ExpriedDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string ImageUrl { get; set; }

    public bool? Status { get; set; }
}