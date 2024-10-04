using DineinEasy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class ReviewRepository:GenericRepository<Review>
    {
        public ReviewRepository() { }
        public ReviewRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
        public async Task<List<Review>> GetReviewsByRestaurantIdAsync(int restaurantId)
        {
            return await _context.Reviews.Where(x=>x.RestaurantId== restaurantId).Include(x=>x.ReviewImages).Include(x=>x.Customer).ToListAsync();
        }
        public async Task<Review> GetReviewByIdAsync(int id)
        {
            return await _context.Reviews.Where(x => x.Id == id).Include(x => x.ReviewImages).FirstOrDefaultAsync();
        }
    }
}
