namespace DineinEasy.API.RequestDTO.Banner
{
    public class UpdatedBanner
    {
        public string ImageUrl { get; set; }
        public int RestaurantId { get; set; }

        public bool? Status { get; set; }
    }
}
