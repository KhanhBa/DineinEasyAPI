namespace DineinEasy.Service.Models;

public partial class CustomerModel
{
    public Guid Id { get; set; } 

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string ImageUrl { get; set; }

    public bool Status { get; set; }


    public virtual ICollection<NotificationModel> Notifications { get; set; } = new List<NotificationModel>();

    public virtual ICollection<OrderBookingModel> OrderBookings { get; set; } = new List<OrderBookingModel>();

    public virtual ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

    public virtual ICollection<SavedRestaurantModel> SavedRestaurants { get; set; } = new List<SavedRestaurantModel>();
}