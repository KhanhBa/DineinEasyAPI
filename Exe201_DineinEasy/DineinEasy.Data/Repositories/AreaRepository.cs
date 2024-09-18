using DineinEasy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DineinEasy.Data.Repositories
{
    public class AreaRepository:GenericRepository<Area>
    {
        public AreaRepository() { }
        public AreaRepository(EXE2_DineinEasyContext context) 
        { 
            _context = context;
        }
    }
}
