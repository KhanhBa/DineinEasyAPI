namespace DineinEasy.API.RequestDTO.Restaurant
{
    public class CreatedRestaurant
    {
        public string Tags { get; set; } = string.Empty;

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Address { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int NumberTable { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Avatar { get; set; }

        public int CategoryId { get; set; }

        public double Rating { get; set; }

        public int AreaId { get; set; }

        public List<CreatedImage> RestaurantImages {  get; set; } = new List<CreatedImage> { };
    }
    public class CreatedImage
    {
        public string ImageUrl { get; set; }
    }
}
