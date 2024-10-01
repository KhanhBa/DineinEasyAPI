using DineinEasy.Data.Models;
using DineinEasy.Data.Models.AdminModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class PackageRepository:GenericRepository<Package>
    {
        public PackageRepository() { }
        public PackageRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
        public async Task<List<AdminData>> GetNewPackages()
        {
            var data = await _context.Customers.GroupBy(x => x.CreateAt.Date).OrderBy(x => x.Key).Select(g => new AdminData
            {
                Date = g.Key,
                Value = g.Count()
            }
                ).ToListAsync();
            return data;
        }
    }
}
