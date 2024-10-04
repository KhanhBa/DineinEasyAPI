using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Models.PartnerModels
{
    public class PartnerModel
    {
        public class ReviewPartner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public int Number { get; set; }
            public string Content { get; set; }
            public DateTime CreateAt { get; set; }
            public List<ImageReview> imageUrls { get; set; }
        }

        public class TimeFramePartner
        {
            public int Id { get; set; }
            public string Day { get; set; }
            public TimeOnly Open { get; set; }
            public TimeOnly Close { get; set; }
        }

        public class RestaurantPartner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string Lastitude { get; set; }
            public string Longtitude { get; set; }
            public string Description { get; set; }
            public TimeOnly Hour { get; set; }
            public string Avatar { get; set; }
            public List<TimeFramePartner> TimeFrames { get; set; }
        }
        public class ImageOfRestaurant
        {
            public int Id { get; set; }
            public string Url { get; set; }
        }

        public class ImageReview
        {
            public string Image { get; set; }
        }
    }
}