namespace DineinEasy.API.RequestDTO.Restaurant
{
    public class UpdatedRestaurant
    {
        public string Tags { get; set; }

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

        public bool Status {  get; set; }

        public List<string> RestaurantImages { get; set; }
    }
}
