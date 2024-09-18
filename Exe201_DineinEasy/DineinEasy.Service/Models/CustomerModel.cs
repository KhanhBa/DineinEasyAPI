namespace DineinEasy.Service.Models;

public partial class CustomerModel
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Password { get; set; }

    public DateTime CreateAt { get; set; }

    public string ImageUrl { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();

    public virtual ICollection<OrderBookingModel> OrderBookings { get; set; } = new List<OrderBookingModel>();

    public virtual ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

    public virtual ICollection<SavedRestaurantModel> SavedRestaurants { get; set; } = new List<SavedRestaurantModel>();
}