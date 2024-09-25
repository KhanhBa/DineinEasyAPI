using DineinEasy.API.RequestDTO.Restaurant;

namespace DineinEasy.API.RequestDTO.Review
{
    public class UpdatedReview
    {
        public int Number { get; set; }

        public string Content { get; set; }

        public int CustomerId { get; set; }

        public int RestaurantId { get; set; }

        public bool Status {  get; set; }
    }
}
