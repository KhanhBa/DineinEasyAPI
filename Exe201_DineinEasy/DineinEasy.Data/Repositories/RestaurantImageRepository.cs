using DineinEasy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    
    }
}
