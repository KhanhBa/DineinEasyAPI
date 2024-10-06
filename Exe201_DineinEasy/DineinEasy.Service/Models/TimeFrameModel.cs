using System;
using System.Collections.Generic;

namespace DineinEasy.Service.Models;

public partial class TimeFrameModel
{
    public int Id { get; set; }

    public string Day { get; set; }

    public TimeOnly OpenedTime { get; set; }

    public TimeOnly ClosedTime { get; set; }

    public int RestaurantId { get; set; }

}