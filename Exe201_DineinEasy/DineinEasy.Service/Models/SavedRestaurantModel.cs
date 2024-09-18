using System;
using System.Collections.Generic;

namespace DineinEasy.Service.Models;

public partial class SavedRestaurantModel
{
    public int Id { get; set; }

    public int CustmerId { get; set; }

    public int RestaurantId { get; set; }

    public virtual CustomerModel Custmer { get; set; }

    public virtual RestaurantModel Restaurant { get; set; }
}