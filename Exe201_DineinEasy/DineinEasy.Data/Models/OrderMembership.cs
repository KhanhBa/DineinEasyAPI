﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DineinEasy.Data.Models;

public partial class OrderMembership
{
    public int Id { get; set; }

    public int RestaurantId { get; set; }

    public int PackageId { get; set; }

    public DateTime ExpiredDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ValidDays { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public double Price { get; set; }

    public double Discount { get; set; }

    public bool Status { get; set; }

    public virtual Package Package { get; set; }

    public virtual Restaurant Restaurant { get; set; }
}