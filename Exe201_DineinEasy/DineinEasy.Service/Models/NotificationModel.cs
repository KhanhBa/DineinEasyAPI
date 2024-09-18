namespace DineinEasy.Service.Models;

public partial class NotificationModel
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Type { get; set; }

    public string Body { get; set; }

    public string ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public int CustomerId { get; set; }

    public virtual CustomerModel Customer { get; set; }
}