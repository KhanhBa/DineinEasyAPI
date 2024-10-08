﻿using DineinEasy.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class RestaurantImageRepository : GenericRepository<RestaurantImage>
    {
        public RestaurantImageRepository() { }
        public RestaurantImageRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }

        public async Task DeleteAllImage(int restaurantId)
        {
            var remove = await _context.RestaurantImages.Where(x => x.RestaurantId == restaurantId).ToArrayAsync();
            if (remove.Length > 0)
            {
                _context.RestaurantImages.RemoveRange(remove);
            }
        }

        public async Task<List<RestaurantImage>> GetRestaurantImagesAsync(int restaurantId)
        {
            return await _context.RestaurantImages.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
