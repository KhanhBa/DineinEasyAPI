using DineinEasy.Data.Models;
using DineinEasy.Data.Models.AdminModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class CustomerRepository:GenericRepository<Customer>
    {
        public CustomerRepository() { }

        public CustomerRepository(EXE2_DineinEasyContext context) {
            _context = context;
        }
        public async Task<List<AdminData>> GetNewCustomers()
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
