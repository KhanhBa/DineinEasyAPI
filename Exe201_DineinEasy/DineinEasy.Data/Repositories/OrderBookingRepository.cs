using DineinEasy.Data.Models;
using DineinEasy.Data.Models.AdminModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class OrderBookingRepository:GenericRepository<OrderBooking>
    {
        public OrderBookingRepository() { }
        public OrderBookingRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
        public async Task<List<AdminData>> GetNewOrderBookings()
        {
            var data = await _context.OrderBookings.GroupBy(x => x.CreatedAt.Value.Date).OrderBy(x => x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Count()
            }
                ).ToListAsync();
            return data;
        }
        public async Task<List<AdminData>> GetNewOrderBookingsbyRestaurantId(int id)
        {
            var data = await _context.OrderBookings.Where(x=>x.RestaurantId==id).GroupBy(x => x.BookingDate.Value.Date).OrderBy(x => x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Count()
            }
                ).ToListAsync();
            return data;
        }
    }
}
