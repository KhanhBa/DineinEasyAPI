using DineinEasy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class RestaurantRepository:GenericRepository<Restaurant>
    {
        public RestaurantRepository() { }
        public RestaurantRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
        public async Task<Restaurant> GetRestaurantForPartner(int restaurant)
        {
            return await _context.Restaurants.Where(x=>x.Id == restaurant)
                .Include(x=>x.RestaurantImages).Include(x=>x.TimeFrames)
                .FirstOrDefaultAsync();
        }
    }
}
