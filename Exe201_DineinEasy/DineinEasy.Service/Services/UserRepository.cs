using DineinEasy.Data.Models;
using DineinEasy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Service.Services
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository() { }
        public UserRepository(EXE2_DineinEasyContext context)
        {
            _context = context;
        }
    }
}
