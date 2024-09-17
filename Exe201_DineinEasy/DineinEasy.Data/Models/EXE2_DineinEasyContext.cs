﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DineinEasy.Data.Models;

public partial class EXE2_DineinEasyContext : DbContext
{
    public EXE2_DineinEasyContext(DbContextOptions<EXE2_DineinEasyContext> options)
        : base(options)
    {
    }
    public EXE2_DineinEasyContext() { }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Banner> Banners { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<OrderBooking> OrderBookings { get; set; }

    public virtual DbSet<OrderMembership> OrderMemberships { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<RestaurantImage> RestaurantImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewImage> ReviewImages { get; set; }

    public virtual DbSet<SavedRestaurant> SavedRestaurants { get; set; }

    public virtual DbSet<TimeFrame> TimeFrames { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Area_1");

            entity.ToTable("Area");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.District)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Ward)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Banner>(entity =>
        {
            entity.ToTable("Banner");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpriedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(12);
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.ToTable("Notification");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Body).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Customer).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notification_Customer");
        });

        modelBuilder.Entity<OrderBooking>(entity =>
        {
            entity.ToTable("OrderBooking");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.BookingTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderBookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_OrderBooking_Customer");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.OrderBookings)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK_OrderBooking_Restaurant");
        });

        modelBuilder.Entity<OrderMembership>(entity =>
        {
            entity.ToTable("OrderMembership");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ExpiredDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Package).WithMany(p => p.OrderMemberships)
                .HasForeignKey(d => d.PackageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderMembership_Package");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.OrderMemberships)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderMembership_Restaurant");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.ToTable("Package");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.ImageUrl).IsRequired();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.ToTable("Restaurant");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.Avatar).IsRequired();
            entity.Property(e => e.CreateAt).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Tags).IsRequired();
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Area).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_Area");

            entity.HasOne(d => d.Category).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Restaurant_Category");
        });

        modelBuilder.Entity<RestaurantImage>(entity =>
        {
            entity.ToTable("RestaurantImage");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Restaurant).WithMany(p => p.RestaurantImages)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK_RestaurantImage_Restaurant");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.ToTable("Review");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Customer).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Customer");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Restaurant");
        });

        modelBuilder.Entity<ReviewImage>(entity =>
        {
            entity.ToTable("ReviewImage");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ImageUrl).IsRequired();

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewImages)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewImage_Review");
        });

        modelBuilder.Entity<SavedRestaurant>(entity =>
        {
            entity.ToTable("SavedRestaurant");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Custmer).WithMany(p => p.SavedRestaurants)
                .HasForeignKey(d => d.CustmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SavedRestaurant_Customer");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.SavedRestaurants)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SavedRestaurant_Restaurant");
        });

        modelBuilder.Entity<TimeFrame>(entity =>
        {
            entity.ToTable("TimeFrame");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Day)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.Restaurant).WithMany(p => p.TimeFrames)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TimeFrame_Restaurant");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(30);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(12);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}