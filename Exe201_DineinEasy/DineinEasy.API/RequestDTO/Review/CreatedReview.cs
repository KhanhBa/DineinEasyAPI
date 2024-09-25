using DineinEasy.API.RequestDTO.Restaurant;

namespace DineinEasy.API.RequestDTO.Review
{
    public class CreatedReview
    {
        public int Number { get; set; }

        public string Content { get; set; }

        public int CustomerId { get; set; }

        public int RestaurantId { get; set; }
        
        public CreatedImage Images { get; set; }
    }
}
