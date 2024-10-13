﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DineinEasy.Data.Models;

public partial class OrderBooking
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? BookingDate { get; set; }

    public TimeSpan? BookingTime { get; set; }

    public int? NumberSeats { get; set; }

    public bool? IsChecking { get; set; }

    public Guid? CustomerId { get; set; }

    public int? RestaurantId { get; set; }

    public string Note { get; set; }

    public bool? Status { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public virtual Customer Customer { get; set; }

    public virtual Restaurant Restaurant { get; set; }
}