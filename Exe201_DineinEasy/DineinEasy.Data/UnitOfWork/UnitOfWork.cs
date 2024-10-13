using DineinEasy.Data.Models;
using DineinEasy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.UnitOfWork
{
    public class UnitOfWork
    {
        public EXE2_DineinEasyContext _context;
        private CustomerRepository _customer;
        private CategoryRepository _category;
        private NotificationRepository _notification;
        private OrderBookingRepository _orderBooking;
        private OrderMembershipRepository _orderMembership;
        private PackageRepository _package;
        private RestaurantRepository _restaurant;
        private ReviewImageRepository _reviewImage;
        private ReviewRepository _review;
        private SavedRestaurantRepository _savedRestaurant;
        private TimeFrameRepository _timeFrame;
        private UserRepository _user;
        private AreaRepository _area;
        private BannerRepository _banner;
        private RestaurantImageRepository _restaurantImage;
        private PackagerRestaurantRepository _packagerRestaurant;

        public UnitOfWork()
        {
            _context ??= new EXE2_DineinEasyContext();
        }
        public UnitOfWork(EXE2_DineinEasyContext context)
        {
            _context ??= context;
        }
        public RestaurantImageRepository RestaurantImageRepository
        {
            get
            {
                return _restaurantImage ??= new RestaurantImageRepository();
            }
        }
        public CustomerRepository CustomerRepository
        {
            get
            {
                return _customer ??= new CustomerRepository();
            }
        }
        public CategoryRepository CategoryRepository
        {
            get
            {
                return _category ??= new CategoryRepository();
            }
        }
        public NotificationRepository NotificationRepository
        {
            get
            {
                return _notification ??= new NotificationRepository();
            }
        }
        public OrderBookingRepository OrderBookingRepository
        {
            get
            {
                return _orderBooking ??= new OrderBookingRepository();
            }
        }
        public OrderMembershipRepository OrderMembershipRepository
        {
            get
            {
                return _orderMembership ??= new OrderMembershipRepository();
            }
        }
        public PackageRepository PackageRepository
        {
            get
            {
                return _package ??= new PackageRepository();
            }
        }
        public RestaurantRepository RestaurantRepository
        {
            get
            {
                return _restaurant ??= new RestaurantRepository();
            }
        }
        public ReviewRepository ReviewRepository
        {
            get
            {
                return _review ??= new ReviewRepository();
            }
        }
        public ReviewImageRepository ReviewImageRepository
        {
            get
            {
                return _reviewImage ??= new ReviewImageRepository();
            }
        }
        public SavedRestaurantRepository SavedRestaurantRepository
        {
            get
            {
                return _savedRestaurant ??= new SavedRestaurantRepository();
            }
        }
        public TimeFrameRepository TimeFrameRepository
        {
            get
            {
                return _timeFrame ??= new TimeFrameRepository();
            }
        }
        public UserRepository UserRepository
        {
            get
            {
                return _user ??= new UserRepository();
            }
        }
        public AreaRepository AreaRepository
        {
            get
            {
                return _area ??= new AreaRepository();
            }
        }
       public BannerRepository BannerRepository
        {

            get
            {
                return _banner ??= new BannerRepository();
            }
        }
        public PackagerRestaurantRepository PackagerRestaurantRepository
        {
            get
            {
                return _packagerRestaurant ??= new PackagerRestaurantRepository();
            }
        }
    }
}
