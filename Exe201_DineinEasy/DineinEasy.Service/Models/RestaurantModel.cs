namespace DineinEasy.Service.Models;

public partial class RestaurantModel
{
    public int Id { get; set; }

    public string Tags { get; set; }

    public DateTime CreateAt { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public string Address { get; set; }

    public string Name { get; set; }
    public string Cuisine { get; set; } 
    public string PriceRange { get; set; } 

    public string Description { get; set; }

    public int NumberTable { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Avatar { get; set; }

    public DateTime UpdateAt { get; set; }

    public int CategoryId { get; set; }

    public double Rating { get; set; }

    public bool Status { get; set; }

    public int AreaId { get; set; }

    public virtual AreaModel Area { get; set; }

    public virtual CategoryModel Category { get; set; }

    public virtual ICollection<OrderBookingModel> OrderBookings { get; set; } = new List<OrderBookingModel>();

    public virtual ICollection<OrderMembershipModel> OrderMemberships { get; set; } = new List<OrderMembershipModel>();

    public virtual ICollection<RestaurantImageModel> RestaurantImages { get; set; } = new List<RestaurantImageModel>();

    public virtual ICollection<ReviewModel> Reviews { get; set; } = new List<ReviewModel>();

    public virtual ICollection<SavedRestaurantModel> SavedRestaurants { get; set; } = new List<SavedRestaurantModel>();

    public virtual ICollection<TimeFrameModel> TimeFrames { get; set; } = new List<TimeFrameModel>();
}