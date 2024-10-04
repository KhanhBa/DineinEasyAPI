using System;
using System.Collections.Generic;

namespace DineinEasy.Service.Models;

public partial class ReviewModel
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string Content { get; set; }

    public DateTime CreateAt { get; set; }

    public int CustomerId { get; set; }

    public int RestaurantId { get; set; }

    public bool Status { get; set; }
   
    public virtual ICollection<ReviewImageModel> ReviewImages { get; set; } = new List<ReviewImageModel>();
}