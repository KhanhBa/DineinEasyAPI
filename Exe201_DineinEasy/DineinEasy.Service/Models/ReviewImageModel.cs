using System;
using System.Collections.Generic;

namespace DineinEasy.Service.Models;

public partial class ReviewImageModel
{
    public int Id { get; set; }

    public int ReviewId { get; set; }

    public string ImageUrl { get; set; }

    public virtual ReviewModel Review { get; set; }
}