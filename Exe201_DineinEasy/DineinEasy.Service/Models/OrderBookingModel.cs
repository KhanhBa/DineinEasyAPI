namespace DineinEasy.Service.Models;

public partial class OrderBookingModel
{
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? BookingDate { get; set; }

    public TimeSpan? BookingTime { get; set; }

    public int? NumberSeats { get; set; }

    public bool? IsChecking { get; set; }

    public Guid? CustomerId { get; set; }

    public int? RestaurantId { get; set; }

    public string Note { get; set; }

    public bool? Status { get; set; }

}