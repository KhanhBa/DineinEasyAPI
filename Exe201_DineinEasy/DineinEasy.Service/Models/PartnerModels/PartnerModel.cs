using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
            public double Latitude { get; set; }
            public double Longtitude { get; set; }
            public string Description { get; set; }
            [JsonPropertyName("AvatarUrl")]
            public string Avatar { get; set; }
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
        public class TimeFrameChange
        {
            public int Id { get; set; }
            public string Day { get; set; }
            public string OpenedTime { get; set; }
            public string ClosedTime { get; set; }
            public int RestaurantId { get; set; }
            public TimeOnly GetOpenedTime() => TimeOnly.Parse(OpenedTime);
            public TimeOnly GetClosedTime() => TimeOnly.Parse(ClosedTime);
        }
        public class RestaurantUpdatePartner
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public double Latitude { get; set; }
            public double Longtitude { get; set; }
            public string Description { get; set; }
            public string AvatarUrl { get; set; }
        }
        public class OrderPartner
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Phone { get; set; }
            public TimeSpan Time { get; set; }
            public DateTime Date { get; set; }
            public Guid CustomerId { get; set; }
            public bool IsCheckin { get; set; }
            public string SpecialRequests { get; set; }
        }
    }
}