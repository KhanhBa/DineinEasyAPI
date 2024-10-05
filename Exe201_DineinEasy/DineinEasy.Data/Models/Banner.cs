﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineinEasy.Data.Models;

public partial class Banner
{
    public int Id { get; set; }

    public DateTime? ExpriedDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string ImageUrl { get; set; }

    public bool? Status { get; set; }
    public int RestaurantId {  get; set; }
    [ForeignKey(nameof(RestaurantId))]
    public virtual Restaurant Restaurant { get; set; }
}