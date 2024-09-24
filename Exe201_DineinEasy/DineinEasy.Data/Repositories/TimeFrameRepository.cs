using DineinEasy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class TimeFrameRepository:GenericRepository<TimeFrame>
    {
        public TimeFrameRepository() { }
        public TimeFrameRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
        public async Task<List<TimeFrame>> GetTimeFramesByRestaurantId(int restaurantId)
        {
            return await _context.TimeFrames.Where(x=>x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
